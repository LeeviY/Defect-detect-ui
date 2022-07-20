using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Defect_detect_ui
{
    public partial class MainWindow : Form
    {
        private string[] _filePaths;
        private int _fileIndex;

        private Detector _detector;
        private CameraCapture _cameraCapture;
        public MainWindow()
        {
            InitializeComponent();

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string imageDirectory = projectDirectory + @"\Images";
            _filePaths = Directory.GetFiles(imageDirectory, "*.bmp");
            string filename = imageDirectory + @"\SV_image_-766126070.bmp";
            //string filename = imageDirectory + @"\SV_Cam1_-12386187.bmp";

            _detector = new Detector(filename);
            _cameraCapture = new CameraCapture(new int[] { 0, 2, 1 });
        }

        public void addImageToBox(Mat image, int boxIndex)
        {
            //Mat resized = new();
            //CvInvoke.Resize(image, resized, new Size(imageBox1.Width, imageBox1.Height));
            ImageBox[] boxes = new ImageBox[] { imageBox1, imageBox2, imageBox3, imageBox4, imageBox5, imageBox6 };
            boxes[boxIndex].Image = image;
        }

        private void setDefaults()
        {
            // Default values for blob detection
            _detector.ObjDetector.setBlobParams();
            _detector.setDefaultValues();

            trackBarArea.Value = (int)(_detector.ObjDetector.BlobParams.MinArea);
            trackBarCircularity.Value = (int)(_detector.ObjDetector.BlobParams.MinCircularity * 100);
            trackBarConvexity.Value = (int)(_detector.ObjDetector.BlobParams.MinConvexity * 100);
            trackBarInertia.Value = (int)(_detector.ObjDetector.BlobParams.MinInertiaRatio * 100);

            trackBarThreshold.Value = _detector.ThresholdOffset;
            trackBarErode.Value = _detector.ErodeIter;
            trackBarDilate.Value = _detector.DilateIter;

            //_detector.detect(this);
        }

        // Reloads images from blob detection
        private void reloadImages()
        {
            _detector.resetOutputImg();

            _detector.runBoardEdgedetect();
            double brigthness = _detector.runKnotStainDetect();
            double darkness = _detector.runHoleCrackDetect();

            _detector.drawObjects();

            addImageToBox(_detector.OutputImages.OutPutImage, 0);
            addImageToBox(_detector.OutputImages.BlackWhiteImage, 1);
            addImageToBox(_detector.OutputImages.CannyImage, 3);
            addImageToBox(_detector.OutputImages.SubBlackWhiteImage, 4);
            addImageToBox(_detector.OutputImages.WhiteBlackImage, 2);
            addImageToBox(_detector.OutputImages.SubWhiteBlackImage, 5);

            labelCrackValue.Text = Math.Round(brigthness, 3).ToString();
            labelStainValue.Text = Math.Round(darkness, 3).ToString();
        }

        private void reloadBlackWhiteImages()
        {
            reloadImages();
            /*detector.resetOutputImg();

            (Mat blackWhiteImg, Mat subBlackWhiteImg) = detector.runKnotStainDetect();

            addImageToBox(detector.getOutputImg(), 0);
            addImageToBox(blackWhiteImg, 1);
            addImageToBox(subBlackWhiteImg, 4);*/
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Set images to scale to box size
            this.imageBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.imageBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.imageBox3.SizeMode = PictureBoxSizeMode.Zoom;
            this.imageBox4.SizeMode = PictureBoxSizeMode.Zoom;
            this.imageBox5.SizeMode = PictureBoxSizeMode.Zoom;
            this.imageBox6.SizeMode = PictureBoxSizeMode.Zoom;

            // Bind label texts to slider values
            labelAreaValue.DataBindings.Add("Text", trackBarArea, "Value");
            labelCircularityValue.DataBindings.Add("Text", trackBarCircularity, "Value");
            labelConvexityValue.DataBindings.Add("Text", trackBarConvexity, "Value");
            labelInertiaValue.DataBindings.Add("Text", trackBarInertia, "Value");
            labelThresholdValue.DataBindings.Add("Text", trackBarThreshold, "Value");
            labelErodeValue.DataBindings.Add("Text", trackBarErode, "Value");
            labelDilateValue.DataBindings.Add("Text", trackBarDilate, "Value");

            setDefaults();
            reloadImages();
        }

        private void trackBarArea_Scroll(object sender, EventArgs e)
        {
            _detector.ObjDetector.setBlobParams(area: trackBarArea.Value);
            reloadImages();
        }

        private void trackBarCircularity_Scroll(object sender, EventArgs e)
        {
            float value = trackBarCircularity.Value / 100.0f;
            _detector.ObjDetector.setBlobParams(circularity: value);
            reloadImages();
        }

        private void trackBarConvexity_Scroll(object sender, EventArgs e)
        {
            float value = trackBarConvexity.Value / 100.0f;
            _detector.ObjDetector.setBlobParams(convexity: value);
            reloadImages();
        }

        private void trackBarInertia_Scroll(object sender, EventArgs e)
        {
            float value = trackBarInertia.Value / 100.0f;
            _detector.ObjDetector.setBlobParams(inertia: value);
            reloadImages();
        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            _detector.ThresholdOffset = trackBarThreshold.Value;
            reloadBlackWhiteImages();
        }

        private void trackBarErode_Scroll(object sender, EventArgs e)
        {
            _detector.ErodeIter = trackBarErode.Value;
            reloadBlackWhiteImages();
        }

        private void trackBarDilate_Scroll(object sender, EventArgs e)
        {
            _detector.DilateIter = trackBarDilate.Value;
            reloadBlackWhiteImages();
        }

        private void buttonDefault_Click_1(object sender, EventArgs e)
        {
            trackBarThreshold.Value = 0;
            setDefaults();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (--_fileIndex < 0)
            {
                _fileIndex = _filePaths.Length - 1;
            }
            _detector.openImage(_filePaths[_fileIndex]);
            reloadImages();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (++_fileIndex > _filePaths.Length - 1)
            {
                _fileIndex = 0;
            }
            _detector.openImage(_filePaths[_fileIndex]);
            reloadImages();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            _cameraCapture.captureCameras();
            _cameraCapture.captureCameras();
        }
    }
}
