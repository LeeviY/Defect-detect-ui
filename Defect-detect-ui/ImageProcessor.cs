using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Defect_detect_ui
{
    internal class ImageProcessor
    {
        public ImageProcessor()
        {

        }

        public Mat readImage(string filename, ImreadModes mode)
        {
            Mat image = CvInvoke.Imread(filename, mode);
            return image;
        }

        public Mat resizeImage(Mat image, int width, int height)
        {
            Mat resized = new();
            CvInvoke.Resize(image, resized, new System.Drawing.Size(width, height));

            return resized;
        }

        public Mat otsuBinariseImage(Mat image)
        {
            Mat binImg = new();
            CvInvoke.Threshold(image, binImg, 128, 255, ThresholdType.Binary | ThresholdType.Otsu);
            return binImg;
        }

        public Mat binariseImage(Mat image, int threshold)
        {
            Mat binImg = new();
            CvInvoke.Threshold(image, binImg, threshold, 255, ThresholdType.Binary);
            return binImg;
        }

        public Mat toCannyImage(Mat image)
        {
            Mat cannyImg = new();
            CvInvoke.Threshold(image, cannyImg, 128, 255, ThresholdType.Binary | ThresholdType.Otsu);
            //resizeImage(image, image.Width / 2, image.Height / 2);
            CvInvoke.Canny(cannyImg, cannyImg, 180, 120);
            //resizeImage(image, image.Width * 2, image.Height * 2);
            return cannyImg;
        }

        public Mat addImageBorder(Mat image, int size)
        {
            Mat borderImg = new();
            CvInvoke.CopyMakeBorder(image, borderImg, size, size, size, size, BorderType.Constant, new MCvScalar(255, 255, 255));
            return borderImg;
        }
    }
}
