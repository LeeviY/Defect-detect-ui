using System.Drawing;
using System.Collections.Generic;

using Emgu.CV;
using Emgu.CV.Structure;

namespace Defect_detect_ui
{
    internal class ObjectDrawer
    {
        public static void DrawRectangles(ref Mat image, RotatedRect box, int offset)
        {
            PointF[] vertices = box.GetVertices();
            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices[i].X -= offset;
                vertices[i].Y -= offset;
            }
            for (int i = 0; i < 4; ++i)
            {
                CvInvoke.Line(image, Point.Round(vertices[i]), 
                    Point.Round(vertices[(i + 1) % 4]), 
                    new Bgr(Color.Green).MCvScalar, 2);
            }
        }

        public static void DrawPoints(ref Mat image, MKeyPoint[] keyPoints, Color color, float rMultiplier = 0.5f, int thickness = 2)
        {
            foreach (MKeyPoint keyPoint in keyPoints)
            {
                CvInvoke.Circle(image, Point.Round(keyPoint.Point), (int)(keyPoint.Size * rMultiplier),
                    new Bgr(color).MCvScalar, thickness);
            }
        }
    }
}
