using Emgu.CV;
using Emgu.CV.Stitching;
using Emgu.CV.Util;
using System.Diagnostics;
using System.Drawing;


namespace Defect_detect_ui
{
    internal class CameraCapture
    {
        private VideoCapture[] _cameras;

        public CameraCapture(int[] cameraIndexes)
        {
            _cameras = new VideoCapture[cameraIndexes.Length];
            for (int i = 0; i < cameraIndexes.Length; i++)
            {
                VideoCapture camera = new VideoCapture(cameraIndexes[i], VideoCapture.API.DShow);
                //camera.
                _cameras[i] = (camera);
            }
        }

        /// <summary>
        /// Captures an image from a webcam
        /// </summary>
        /// <param name="camIndex">Index of camera given by os</param>
        /// <returns>Image as a matrix</returns>
        public Mat capture(int camIndex = 0)
        {
            VideoCapture capture = new(camIndex, VideoCapture.API.DShow);
            Mat frame = capture.QueryFrame();
            return frame;
        }

        /// <summary>
        /// Creates an image from cameras of given indexes
        /// </summary>
        /// <param name="camIndexes">a list of indexes for cameras to be used</param>
        public void captureCameras()
        {
            /*Mat output = capture(camIndexes[0]);
            if (output == null)
            {
                Debug.WriteLine("Failed to access camera");
                return;
            }
            Size imageSize = output.Size;

            for (int i = 1; i < camIndexes.Length; ++i)
            {
                Mat frame = capture(camIndexes[i]);

                // Check if a frame was captured.
                // Also continues if camera doesn't exists
                if (frame == null) continue;

                CvInvoke.Resize(frame, frame, imageSize);
                CvInvoke.HConcat(output, frame, output);
            }

            CvInvoke.Imshow("", output);*/


            Mat? output = null;

            int count = 0;
            foreach (VideoCapture capture in _cameras)
            {

                Mat frame = new();//capture.QueryFrame();
                capture.Retrieve(frame);
                if (output == null) output = frame;
                else
                {
                    CvInvoke.HConcat(output.Clone(), frame, output);
                }
                CvInvoke.Imshow(count++.ToString(), frame);
            }

            /*for (int i = 0; i < camIndexes.Length; ++i)
            {
                Mat frame = capture(camIndexes[i]);

                // Check if a frame was captured.
                // Also continues if camera doesn't exists
                if (frame == null) continue;

                if (output == null) output = frame;
                else
                {
                    CvInvoke.HConcat(output, frame, output);
                }

                //CvInvoke.Imshow(i.ToString(), frame);
            }*/
            CvInvoke.Imshow("", output);
        }

        public void stitchImages(ref VectorOfMat images)
        {
            Stitcher stitcher = new(Stitcher.Mode.Panorama);

            Mat result = new();
            var state = stitcher.Stitch(images, result);
            Debug.WriteLine(state);

            Mat output = images[0].Clone();
            for (int i = 1; i < images.Size; ++i)
            {
                Debug.WriteLine(i);
                Mat frame = images[i].Clone();
                frame = new Mat(frame, new Rectangle(1920 / 2, 10 * i, 1920 / 2, 1080));
                CvInvoke.HConcat(output, frame, output);
            }

            CvInvoke.Imshow("pano", output);
        }
    }
}
