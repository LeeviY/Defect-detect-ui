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

        public RotatedRect BoardEdge { get; private set; }
        public MKeyPoint[] Knots { get; private set; }
        public MKeyPoint[] Holes { get; private set; }
        public ImageSet OutputImages; //{ get; private set; }

        public struct ImageSet
        {
            public ImageSet()
            {
                OutPutImage = new();
                ColorImage = new();
                GrayImage = new();
                CannyImage = new();
                BlackWhiteImage = new();
                WhiteBlackImage = new();
                SubBlackWhiteImage = new();
                SubWhiteBlackImage = new();
            }

            public Mat OutPutImage;
            public Mat ColorImage;
            public Mat GrayImage;
            public Mat CannyImage;
            public Mat BlackWhiteImage;
            public Mat WhiteBlackImage;
            public Mat SubBlackWhiteImage;
            public Mat SubWhiteBlackImage;
        }

        public Detector(string filename)
        {
            ObjDetector = new();
            OutputImages = new();

            _outPutImg = new Mat();
            _colorImg = new Mat();
            _grayImg = new Mat();

            ThresholdOffset = 0;
            ErodeIter = 3;
            DilateIter = 6;

            Knots = System.Array.Empty<MKeyPoint>();
            Holes = System.Array.Empty<MKeyPoint>();

            openImage(filename);
        }

        public void openImage(string filename)
        {
            Debug.WriteLine("Images from " + filename);
            _colorImg = ImageProcessor.ReadImage(filename, ImreadModes.Color);
            _outPutImg = _colorImg.Clone();
            _grayImg = new();
            CvInvoke.CvtColor(_colorImg, _grayImg, ColorConversion.Bgr2Gray);
        }

        private void detectBoardEdge(ref Mat inImg)
        {
            // Add padding around image
            Mat borderImage = ImageProcessor.AddImageBorder(inImg, OUTER_PADDING);

            // Apply smoothing
            CvInvoke.Erode(borderImage, borderImage, null, new Point(-1, -1), 3,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Dilate(borderImage, borderImage, null, new Point(-1, -1), 6,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);

            Mat cannyImage = ImageProcessor.ToCannyImage(borderImage);
            this.OutputImages.CannyImage = cannyImage;

            List<RotatedRect> boxList = ObjDetector.detectRectangles(ref cannyImage);

            // If no border is found sets board edge as half of image size.
            if (boxList.Count == 0)
            {
                this.BoardEdge = new RotatedRect(new PointF(_colorImg.Width / 2, _colorImg.Height / 2),
                                                 new SizeF(_colorImg.Width, _colorImg.Height), 0);
            }
            else
            {
                this.BoardEdge = boxList[0];
            }
        }

        private void detectHoles(ref Mat inImg)
        {
            this.OutputImages.WhiteBlackImage = ImageProcessor.OtsuBinariseImage(inImg);
            this.Holes = ObjDetector.detectBlobs(ref this.OutputImages.WhiteBlackImage, 255);
        }

        private int calculateMeanColor(ref Mat inImg)
        {
            MCvScalar means = CvInvoke.Mean(inImg);
            return (int)(means.V0 + means.V1) / 2;
        }

        private void detectKnots(ref Mat inImg, int threshold, int erode = 3, int dilate = 6)
        {
            this.OutputImages.BlackWhiteImage = ImageProcessor.BinariseImage(inImg, threshold);
            CvInvoke.Erode(this.OutputImages.BlackWhiteImage, this.OutputImages.BlackWhiteImage, null, new Point(-1, -1), erode,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Dilate(this.OutputImages.BlackWhiteImage, this.OutputImages.BlackWhiteImage, null, new Point(-1, -1), dilate,
                BorderType.Default, CvInvoke.MorphologyDefaultBorderValue);

            this.Knots = ObjDetector.detectBlobs(ref this.OutputImages.BlackWhiteImage, 0);
        }

        private void detectStains()
        {
            this.OutputImages.SubBlackWhiteImage = this.OutputImages.BlackWhiteImage.Clone();
            ObjectDrawer.DrawPoints(ref this.OutputImages.SubBlackWhiteImage, this.Knots, Color.White, 2, -1);
            double meanDarkness = CvInvoke.Mean(this.OutputImages.BlackWhiteImage).ToArray()[0];

            Debug.WriteLine($"Mean: {meanDarkness}, Mean diff {meanDarkness - last} ");
            this.last = meanDarkness;
        }

        private void detectCracks(RotatedRect roi)
        {
            this.OutputImages.SubWhiteBlackImage = this.OutputImages.WhiteBlackImage.Clone();
            ObjectDrawer.DrawPoints(ref this.OutputImages.SubWhiteBlackImage, this.Holes, Color.Black, 2, -1);
            Rectangle rect = new Rectangle((int)(roi.Center.X - roi.Size.Width / 2),
                                        (int)(roi.Center.Y - roi.Size.Height / 2),
                                        (int)(roi.Size.Height), (int)(roi.Size.Width));
            Image<Gray, byte> img = this.OutputImages.SubWhiteBlackImage.ToImage<Gray, byte>();
            img.ROI = rect;
            double[] meanBrightnessArr = CvInvoke.Mean(img.Copy()).ToArray();
            double meanBrightness = meanBrightnessArr.Sum() / meanBrightnessArr.Length;
        }

        public void runBoardEdgedetect()
        {
            detectBoardEdge(ref this._grayImg);
        }

        // Runs hole and crack detection on grayImg and writes result to outPutImg
        // Returns images of bright spots
        public double runHoleCrackDetect()
        {
            detectHoles(ref this._grayImg);
            detectCracks(this.BoardEdge);

            double brightness = ObjDetector.detectCracks(ref this.OutputImages.SubWhiteBlackImage, this.BoardEdge);

            return brightness;
        }

        // Runs knot and stain detection on grayImg and writes result to outPutImg
        // Returns images of dark spots
        public double runKnotStainDetect()
        {
            int meanColor = calculateMeanColor(ref this._colorImg) / 2 + this.ThresholdOffset;

            detectKnots(ref this._grayImg, meanColor, this.ErodeIter, this.DilateIter);
            detectStains();

            double darkness = ObjDetector.detectStains(ref this.OutputImages.SubBlackWhiteImage);

            return darkness;
        }

        public void drawObjects()
        {
            ObjectDrawer.DrawRectangles(ref this.OutputImages.OutPutImage, this.BoardEdge, OUTER_PADDING);
            ObjectDrawer.DrawPoints(ref this.OutputImages.OutPutImage, this.Holes, Color.Blue);
            ObjectDrawer.DrawPoints(ref this.OutputImages.OutPutImage, this.Knots, Color.Red);
        }

        public void resetOutputImg()
        {
            this.OutputImages.OutPutImage = _colorImg.Clone();
        }

        public void setDefaultValues()
        {
            this.ThresholdOffset = 0;
            this.ErodeIter = 3;
            this.DilateIter = 6;
        }
    }
}