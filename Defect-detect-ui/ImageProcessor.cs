using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Defect_detect_ui
{
    internal class ImageProcessor
    {
        public static Mat ReadImage(string filename, ImreadModes mode)
        {
            Mat image = CvInvoke.Imread(filename, mode);
            return image;
        }

        public static Mat ResizeImage(Mat image, int width, int height)
        {
            Mat resized = new();
            CvInvoke.Resize(image, resized, new System.Drawing.Size(width, height));

            return resized;
        }

        public static Mat OtsuBinariseImage(Mat image)
        {
            Mat binImg = new();
            CvInvoke.Threshold(image, binImg, 128, 255, ThresholdType.Binary | ThresholdType.Otsu);
            return binImg;
        }

        public static Mat BinariseImage(Mat image, int threshold)
        {
            Mat binImg = new();
            CvInvoke.Threshold(image, binImg, threshold, 255, ThresholdType.Binary);
            return binImg;
        }

        public static Mat ToCannyImage(Mat image)
        {
            Mat cannyImg = OtsuBinariseImage(image);
            ResizeImage(cannyImg, image.Width / 2, image.Height / 2);
            CvInvoke.Canny(cannyImg, cannyImg, 100, 200);
            ResizeImage(cannyImg, image.Width * 2, image.Height * 2);
            return cannyImg;
        }

        public static Mat AddImageBorder(Mat image, int size)
        {
            Mat borderImg = new();
            CvInvoke.CopyMakeBorder(image, borderImg, size, size, size, size, 
                BorderType.Constant, new MCvScalar(255, 255, 255));
            return borderImg;
        }
    }
}
