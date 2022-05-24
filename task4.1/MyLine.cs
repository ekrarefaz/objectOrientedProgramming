using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        public MyLine(Color Color, float startX, float startY, float endX = 100, float endY = 100) : base()
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }
        public MyLine() : this(Color.Orange, 0, 0) { }
        public float EndX
        {
            get
            {
                return _endX;
            }
        }
        public float EndY
        {
            get
            {
                return _endY;
            }
        }
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(Color.BrightGreen,X,Y,EndX,EndY);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(
            clr: Color.White,
            x: X,
            y: Y,
            radius: 2);

            SplashKit.DrawCircle(
            clr: Color.White,
            x: EndX,
            y: EndY,
            radius: 2);
        }
        public override bool IsAt(Point2D pt)
        {

            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
        }
    }
}
