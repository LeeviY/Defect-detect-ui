using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Defect_detect_ui
{
    internal class Detector
    {
        private ImageProcessor ImgProcessor;
        public ObjectDetector ObjDetector { get; set; }
        private ObjectDrawer ObjDrawer;

        private int Padding;

        private Mat outPutImg;
        private Mat colorImg;
        private Mat grayImg;
        private RotatedRect roi;

        public int thresholdOffset;
        public int erodeIter;
        public int dilateIter;

        public Detector(string filename)
        {
            ImgProcessor = new();
            ObjDetector = new();
            ObjDrawer = new();
            Padding = 50;

            thresholdOffset = 0;
            erodeIter = 3;
            dilateIter = 6;

            openImage(filename);
        }

        public void openImage(string filename)
        {
            colorImg = ImgProcessor.readImage(filename, ImreadModes.Color);
            outPutImg = colorImg.Clone();
            grayImg = new();
            CvInvoke.CvtColor(colorImg, grayImg, ColorConversion.Bgr2Gray);
        }

        private (List<RotatedRect>, Mat) detectBoardEdge(ref Mat inImg, ref Mat outImg)
        {
            Mat borderImage = ImgProcessor.addImageBorder(inImg, this.Padding);
            Mat cannyImage = ImgProcessor.toCannyImage(borderImage);
            List<RotatedRect> boxList = ObjDetector.detectRectangles(ref cannyImage);
            ObjDrawer.drawRectangles(ref outImg, boxList, Padding);

            if (boxList.Count == 0)
            {
                this.roi = new RotatedRect(new PointF(colorImg.Width / 2, colorImg.Height / 2), 
                                            new SizeF(colorImg.Width, colorImg.Height), 0);
            }
            else
            {
                this.roi = boxList[0];
            }

            return (boxList, cannyImage);
        }

        private (MKeyPoint[], Mat) detectHoles(ref Mat inImg, ref Mat outImg)
        {
            Mat whiteBlackImg = ImgProcessor.otsuBinariseImage(inImg);
            MKeyPoint[] brightKeypoints = ObjDetector.detectBlobs(ref whiteBlackImg, 255);
            ObjDrawer.drawPoints(ref outImg, ref brightKeypoints, Color.Blue);
            return (brightKeypoints, whiteBlackImg);
        }

        private int calculateMeanColor(ref Mat inImg)
        {
            MCvScalar means = CvInvoke.Mean(inImg);

            return (int)(means.V0 + means.V1) / 2;
        }

        private (MKeyPoint[], Mat) detectKnots(ref Mat inImg, ref Mat outImg, int threshold, int erode = 3, int dilate = 6)
        {
            Mat blackWhiteImg = ImgProcessor.binariseImage(inImg, threshold);
            CvInvoke.Erode(blackWhiteImg, blackWhiteImg, null, new Point(-1, -1), erode,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Dilate(blackWhiteImg, blackWhiteImg, null, new Point(-1, -1), dilate,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);

            MKeyPoint[] darkKeyPoints = ObjDetector.detectBlobs(ref blackWhiteImg, 0);
            ObjDrawer.drawPoints(ref outImg, ref darkKeyPoints, Color.Red);
            return (darkKeyPoints, blackWhiteImg);
        }

        private (bool, Mat) detectStains(ref Mat inImg, ref MKeyPoint[] darkKeyPoints)
        {
            Mat subBlackWhiteImg = inImg.Clone();
            ObjDrawer.drawPoints(ref subBlackWhiteImg, ref darkKeyPoints, Color.White, 2, -1);
            double[] meanDarknessArr = CvInvoke.Mean(inImg).ToArray();
            double meanDarkness = meanDarknessArr.Sum() / meanDarknessArr.Length;

            return (false, subBlackWhiteImg);
        }

        private (bool, Mat) detectCracks(ref Mat inImg, ref MKeyPoint[] brightKeypoints, RotatedRect roi)
        {
            Mat subWhiteBlackImg = inImg.Clone();
            ObjDrawer.drawPoints(ref subWhiteBlackImg, ref brightKeypoints, Color.Black, 2, -1);
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
            (List<RotatedRect> boxList, Mat cannyImg) = detectBoardEdge(ref this.grayImg, ref this.outPutImg);
            return cannyImg;
        }

        // Runs hole and crack detection on grayImg and writes result to outPutImg
        // Returns images of bright spots
        public (Mat, Mat) runHoleCrackDetect()
        {
            (MKeyPoint[] brightKeypoints, Mat whiteBlackImg) = detectHoles(ref this.grayImg, ref this.outPutImg);
            (bool isCracked, Mat subWhiteBlackImg) = detectCracks(ref whiteBlackImg, ref brightKeypoints, this.roi);

            return (whiteBlackImg, subWhiteBlackImg);
        }

        // Runs knot and stain detection on grayImg and writes result to outPutImg
        // Returns images of dark spots
        public (Mat, Mat) runKnotStainDetect()
        {
            int meanColor = calculateMeanColor(ref this.outPutImg);
            (MKeyPoint[] darkKeyPoints, Mat blackWhiteImg) = detectKnots(ref this.grayImg, ref this.outPutImg, 
                meanColor / 2 + this.thresholdOffset, this.erodeIter, this.dilateIter);
            (bool isStained, Mat subBlackWhiteImg) = detectStains(ref blackWhiteImg, ref darkKeyPoints);

            return (blackWhiteImg, subBlackWhiteImg);
        }

        public void detect(MainWindow win)
        {
            #region Detect board edge
            (List<RotatedRect> boxList, Mat cannyImg) = detectBoardEdge(ref grayImg, ref outPutImg);
            #endregion

            #region Detect holes
            (MKeyPoint[] brightKeypoints, Mat whiteBlackImg) = detectHoles(ref grayImg, ref outPutImg);
            #endregion

            #region Detect knots
            int meanColor = calculateMeanColor(ref outPutImg);
            (MKeyPoint[] darkKeyPoints, Mat blackWhiteImg) = detectKnots(ref grayImg, ref outPutImg, 
                meanColor / 2 + this.thresholdOffset, this.erodeIter, this.dilateIter);
            #endregion

            #region Detect stains
            (bool isStained, Mat subBlackWhiteImg) = detectStains(ref blackWhiteImg, ref darkKeyPoints);
            #endregion

            #region Detect cracks
            (bool isCracked, Mat subWhiteBlackImg) = detectCracks(ref whiteBlackImg, ref brightKeypoints, this.roi);
            #endregion

            win.addImageToBox(outPutImg, 0);
            win.addImageToBox(cannyImg, 3);
            win.addImageToBox(blackWhiteImg, 1);
            win.addImageToBox(subBlackWhiteImg, 4);
            win.addImageToBox(whiteBlackImg, 2);
            win.addImageToBox(subWhiteBlackImg, 5);
        }

        public Mat getOutputImg()
        {
            return outPutImg;
        }

        public void resetOutputImg()
        {
            outPutImg = colorImg.Clone();
        }

        public void setDefaultValues()
        {
            this.thresholdOffset = 0;
            this.erodeIter = 3;
            this.dilateIter = 6;
        }
    }
}