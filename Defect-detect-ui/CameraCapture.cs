using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Drawing;
using Emgu.CV.CvEnum;

using System.Windows.Forms;


namespace Defect_detect_ui
{
    internal class CameraCapture
    {
        /// <summary>
        /// Captures an image from a webcam
        /// </summary>
        /// <param name="camIndex">Index of camera given by os</param>
        /// <returns>Image as a matrix</returns>
        public static Mat capture(int camIndex = 0)
        {
            VideoCapture capture = new(camIndex, VideoCapture.API.DShow);
            Mat frame = capture.QueryFrame();
            return frame;
        }

        /// <summary>
        /// Creates an image from cameras of given indexes
        /// </summary>
        /// <param name="camIndexes">a list of indexes for cameras to be used</param>
        public static void captureCameras(int[] camIndexes)
        {
            Mat output = capture(camIndexes[0]);
            Size imageSize = output.Size;

            for (int i = 1; i < camIndexes.Length; ++i)
            {
                Mat frame = capture(camIndexes[i]);
                CvInvoke.Resize(frame, frame, imageSize);
                CvInvoke.HConcat(output, frame, output);
            }

            CvInvoke.Imshow("", output);
        }
    }
}
