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
        public static void capture(int camIndex = 0)
        {
            VideoCapture capture = new(camIndex, VideoCapture.API.DShow);
            using (var frame = capture.QueryFrame())
            {
                CvInvoke.Imshow("a", frame);
                //frame.Save("frame.jpg");
            }
        }
    }
}
