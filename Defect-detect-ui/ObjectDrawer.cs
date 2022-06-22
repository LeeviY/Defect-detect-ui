using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Features2D;

namespace Defect_detect_ui
{
    internal class ObjectDrawer
    {
        public ObjectDrawer()
        {

        }

        public void drawRectangles(ref Mat image, List<RotatedRect> boxList, int offset)
        {
            foreach (RotatedRect box in boxList)
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
        }

        public void drawPoints(ref Mat image, ref MKeyPoint[] keyPoints, Color color, float rMultiplier = 0.5f, int thickness = 2)
        {
            foreach (MKeyPoint keyPoint in keyPoints)
            {
                CvInvoke.Circle(image, Point.Round(keyPoint.Point), (int)(keyPoint.Size * rMultiplier),
                    new Bgr(color).MCvScalar, thickness);
            }
        }
    }
}
