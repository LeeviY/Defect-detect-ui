using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Features2D;

namespace Defect_detect_ui
{
    internal class ObjectDetector
    {
        public struct RectangleParams 
        {
            public RectangleParams(int minArea, int minAngle, int maxAngle)
            {
                MinArea = minArea;
                MinTheta = minAngle;
                MaxTheta = maxAngle;
            }

            public int MinArea;
            public int MinTheta;
            public int MaxTheta;                
        };

        public SimpleBlobDetectorParams BlobParams;
        public RectangleParams RectParams;

        public ObjectDetector()
        {
            BlobParams = new();
            RectParams = new();
            setBlobParams();
            setRectangleParams();
        }

        public List<RotatedRect> detectRectangles(ref Mat image)
        {
            List<RotatedRect> boxList = new();

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
                VectorOfPoint contour = contours[i];
                VectorOfPoint approxContour = new();

                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05,true);
                if (CvInvoke.ContourArea(approxContour, false) > 250)
                {
                    if (approxContour.Size == 4)
                    {
                        #region determine if all the angles in the contour are within [80, 100] degree
                        bool isRectangle = true;
                        Point[] pts = approxContour.ToArray();
                        LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                        for (int j = 0; j < edges.Length; j++)
                        {
                            double angle = Math.Abs(
                                edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                            if (angle < 80 || angle > 100)
                            {
                                isRectangle = false;
                                break;
                            }
                        }

                        #endregion
                        if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                    }
                }
            }

            return boxList;
        }

        public void setBlobParams(int area = 100, float circularity = 0.1f, 
            float convexity = 0f, float inertia = 0.01f)
        {
            this.BlobParams.FilterByArea = true;
            this.BlobParams.MinArea = area;
            this.BlobParams.FilterByCircularity = true;
            this.BlobParams.MinCircularity = circularity;
            this.BlobParams.FilterByConvexity = true;
            this.BlobParams.MinConvexity = convexity;
            this.BlobParams.FilterByInertia = true;
            this.BlobParams.MinInertiaRatio = inertia;
            this.BlobParams.FilterByColor = true;
        }

        public void setRectangleParams(int area = 250, int minAngle = 80, int maxAngle = 100)
        {
            this.RectParams.MinArea = area;
            this.RectParams.MinTheta = minAngle;
            this.RectParams.MaxTheta = maxAngle;
        }

        public MKeyPoint[] detectBlobs(ref Mat image, Byte color)
        {
            this.BlobParams.blobColor = color;
            SimpleBlobDetector detector = new (this.BlobParams);
            MKeyPoint[] keypoints = detector.Detect(image);

            return keypoints;
        }
    }
}
