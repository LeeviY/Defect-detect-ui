using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;


using Emgu.CV;
using Emgu.CV.UI;

namespace Defect_detect_ui
{
    public partial class MainWindow : Form
    {
        private string[] _filePaths;
        private int _fileIndex;

        private Detector _detector;
        public MainWindow()
        {
            InitializeComponent();

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string imageDirectory = projectDirectory + @"\Images";
            _filePaths = Directory.GetFiles(imageDirectory, "*.bmp");
            string filename = imageDirectory + @"\SV_image_-766126070.bmp";

            _detector = new Detector(filename);

            CameraCapture.capture();
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

            _detector.detect(this);
        }

        // Reloads images from blob detection
        private void reloadBlobImages()
        {
            _detector.resetOutputImg();

            (Mat blackWhiteImg, Mat subBlackWhiteImg) = _detector.runKnotStainDetect();
            (Mat whiteBlackImg, Mat subWhiteBlackImg) = _detector.runHoleCrackDetect();

            addImageToBox(_detector.getOutputImg(), 0);
            addImageToBox(blackWhiteImg, 1);
            addImageToBox(subBlackWhiteImg, 4);
            addImageToBox(whiteBlackImg, 2);
            addImageToBox(subWhiteBlackImg, 5);
        }

        private void reloadBlackWhiteImages()
        {
            reloadBlobImages();
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
        }

        private void trackBarArea_Scroll(object sender, EventArgs e)
        {
            _detector.ObjDetector.setBlobParams(area: trackBarArea.Value);
            reloadBlobImages();
        }

        private void trackBarCircularity_Scroll(object sender, EventArgs e)
        {
            float value = trackBarCircularity.Value / 100.0f;
            _detector.ObjDetector.setBlobParams(circularity: value);
            reloadBlobImages();
        }

        private void trackBarConvexity_Scroll(object sender, EventArgs e)
        {
            float value = trackBarConvexity.Value / 100.0f;
            _detector.ObjDetector.setBlobParams(convexity: value);
            reloadBlobImages();
        }

        private void trackBarInertia_Scroll(object sender, EventArgs e)
        {
            float value = trackBarInertia.Value / 100.0f;
            _detector.ObjDetector.setBlobParams(inertia: value);
            reloadBlobImages();
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
            _detector.detect(this);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (++_fileIndex > _filePaths.Length - 1)
            {
                _fileIndex = 0;
            }
            _detector.openImage(_filePaths[_fileIndex]);
            _detector.detect(this);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            CameraCapture.captureCameras(new int[2] { 0, 1 });
            CameraCapture.captureCameras(new int[2] { 0, 1 });
        }
    }
}
