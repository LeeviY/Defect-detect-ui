using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Defect_detect_ui
{
    internal class Detector
    {
        public ObjectDetector ObjDetector;

        private const int OUTER_PADDING = 50;

        private Mat _outPutImg;
        private Mat _colorImg;
        private Mat _grayImg;
        private RotatedRect _roi;

        public int ThresholdOffset;
        public int ErodeIter;
        public int DilateIter;

        private double last;

        public Detector(string filename)
        {
            ObjDetector = new();

            _outPutImg = new Mat();
            _colorImg = new Mat();
            _grayImg = new Mat();

            ThresholdOffset = 0;
            ErodeIter = 3;
            DilateIter = 6;

            openImage(filename);
        }

        public void openImage(string filename)
        {
            _colorImg = ImageProcessor.ReadImage(filename, ImreadModes.Color);
            _outPutImg = _colorImg.Clone();
            _grayImg = new();
            CvInvoke.CvtColor(_colorImg, _grayImg, ColorConversion.Bgr2Gray);
        }

        private (List<RotatedRect>, Mat) detectBoardEdge(ref Mat inImg, ref Mat outImg)
        {
            Mat borderImage = ImageProcessor.AddImageBorder(inImg, OUTER_PADDING);

            CvInvoke.Erode(borderImage, borderImage, null, new Point(-1, -1), 3,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Dilate(borderImage, borderImage, null, new Point(-1, -1), 6,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);

            Mat cannyImage = ImageProcessor.ToCannyImage(borderImage);

            CvInvoke.Imshow("", cannyImage);

            List<RotatedRect> boxList = ObjDetector.detectRectangles(ref cannyImage);
            ObjectDrawer.DrawRectangles(ref outImg, boxList, OUTER_PADDING);
           
            //CvInvoke.DrawContours(outImg, ObjDetector.detectRectangle(ref cannyImage), -1, new Bgr(Color.Green).MCvScalar);

            if (boxList.Count == 0)
            {
                this._roi = new RotatedRect(new PointF(_colorImg.Width / 2, _colorImg.Height / 2), 
                                            new SizeF(_colorImg.Width, _colorImg.Height), 0);
            }
            else
            {
                this._roi = boxList[0];
            }

            return (boxList, cannyImage);
        }

        private (MKeyPoint[], Mat) detectHoles(ref Mat inImg, ref Mat outImg)
        {
            Mat whiteBlackImg = ImageProcessor.OtsuBinariseImage(inImg);
            MKeyPoint[] brightKeypoints = ObjDetector.detectBlobs(ref whiteBlackImg, 255);
            ObjectDrawer.DrawPoints(ref outImg, ref brightKeypoints, Color.Blue);
            return (brightKeypoints, whiteBlackImg);
        }

        private int calculateMeanColor(ref Mat inImg)
        {
            MCvScalar means = CvInvoke.Mean(inImg);

            return (int)(means.V0 + means.V1) / 2;
        }

        private (MKeyPoint[], Mat) detectKnots(ref Mat inImg, ref Mat outImg, int threshold, int erode = 3, int dilate = 6)
        {
            Mat blackWhiteImg = ImageProcessor.BinariseImage(inImg, threshold);
            CvInvoke.Erode(blackWhiteImg, blackWhiteImg, null, new Point(-1, -1), erode,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Dilate(blackWhiteImg, blackWhiteImg, null, new Point(-1, -1), dilate,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);

            MKeyPoint[] darkKeyPoints = ObjDetector.detectBlobs(ref blackWhiteImg, 0);
            ObjectDrawer.DrawPoints(ref outImg, ref darkKeyPoints, Color.Red);
            return (darkKeyPoints, blackWhiteImg);
        }

        private (bool, Mat) detectStains(ref Mat inImg, ref MKeyPoint[] darkKeyPoints)
        {
            Mat subBlackWhiteImg = inImg.Clone();
            ObjectDrawer.DrawPoints(ref subBlackWhiteImg, ref darkKeyPoints, Color.White, 2, -1);
            double meanDarkness = CvInvoke.Mean(inImg/*subBlackWhiteImg*/).ToArray()[0];

            Debug.WriteLine($"Mean: {meanDarkness}, Mean diff {meanDarkness - last} ");
            this.last = meanDarkness;

            return (false, subBlackWhiteImg);
        }

        private (bool, Mat) detectCracks(ref Mat inImg, ref MKeyPoint[] brightKeypoints, RotatedRect roi)
        {
            Mat subWhiteBlackImg = inImg.Clone();
            ObjectDrawer.DrawPoints(ref subWhiteBlackImg, ref brightKeypoints, Color.Black, 2, -1);
            Mat roiWhiteBlackImage = new();
            Rectangle rect = new Rectangle((int)(roi.Center.X - roi.Size.Width / 2),
                                        (int)(roi.Center.Y - roi.Size.Height / 2),
                                        (int)(roi.Size.Height), (int)(roi.Size.Width));
            //CvInvoke.cvGetSubRect(whiteBlackImg, roiWhiteBlackImage, rect);
            Image<Gray, byte> img = subWhiteBlackImg.ToImage<Gray, byte>();
            img.ROI = rect;
            double[] meanBrightnessArr = CvInvoke.Mean(img.Copy()).ToArray();
            double meanBrightness = meanBrightnessArr.Sum() / meanBrightnessArr.Length;

            return (false, subWhiteBlackImg);
        }

        // Runs edge detection
        public Mat runBoardEdgeDetect()
        {
            (List<RotatedRect> boxList, Mat cannyImg) = detectBoardEdge(ref this._grayImg, ref this._outPutImg);
            return cannyImg;
        }

        // Runs hole and crack detection on grayImg and writes result to outPutImg
        // Returns images of bright spots
        public (Mat, Mat) runHoleCrackDetect()
        {
            (MKeyPoint[] brightKeypoints, Mat whiteBlackImg) = detectHoles(ref this._grayImg, ref this._outPutImg);
            (bool isCracked, Mat subWhiteBlackImg) = detectCracks(ref whiteBlackImg, ref brightKeypoints, this._roi);

            return (whiteBlackImg, subWhiteBlackImg);
        }

        // Runs knot and stain detection on grayImg and writes result to outPutImg
        // Returns images of dark spots
        public (Mat, Mat) runKnotStainDetect()
        {
            int meanColor = calculateMeanColor(ref this._colorImg);

            (MKeyPoint[] darkKeyPoints, Mat blackWhiteImg) = detectKnots(ref this._grayImg, ref this._outPutImg, 
                meanColor / 2 + this.ThresholdOffset, this.ErodeIter, this.DilateIter);
            (bool isStained, Mat subBlackWhiteImg) = detectStains(ref blackWhiteImg, ref darkKeyPoints);

            return (blackWhiteImg, subBlackWhiteImg);
        }

        public void detect(MainWindow win)
        {
            #region Detect board edge
            (List<RotatedRect> boxList, Mat cannyImg) = detectBoardEdge(ref _grayImg, ref _outPutImg);
            #endregion

            #region Detect holes
            (MKeyPoint[] brightKeypoints, Mat whiteBlackImg) = detectHoles(ref _grayImg, ref _outPutImg);
            #endregion

            #region Detect knots
            int meanColor = calculateMeanColor(ref _outPutImg);
            (MKeyPoint[] darkKeyPoints, Mat blackWhiteImg) = detectKnots(ref _grayImg, ref _outPutImg, 
                meanColor / 2 + this.ThresholdOffset, this.ErodeIter, this.DilateIter);
            #endregion

            #region Detect stains
            (bool isStained, Mat subBlackWhiteImg) = detectStains(ref blackWhiteImg, ref darkKeyPoints);
            #endregion

            #region Detect cracks
            (bool isCracked, Mat subWhiteBlackImg) = detectCracks(ref whiteBlackImg, ref brightKeypoints, this._roi);
            #endregion

            win.addImageToBox(_outPutImg, 0);
            win.addImageToBox(cannyImg, 3);
            win.addImageToBox(blackWhiteImg, 1);
            win.addImageToBox(subBlackWhiteImg, 4);
            win.addImageToBox(whiteBlackImg, 2);
            win.addImageToBox(subWhiteBlackImg, 5);
        }

        public Mat getOutputImg()
        {
            return _outPutImg;
        }

        public void resetOutputImg()
        {
            _outPutImg = _colorImg.Clone();
        }

        public void setDefaultValues()
        {
            this.ThresholdOffset = 0;
            this.ErodeIter = 3;
            this.DilateIter = 6;
        }
    }
}