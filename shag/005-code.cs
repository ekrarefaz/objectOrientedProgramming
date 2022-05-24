using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _length;

        public MyLine(Color Clr, float x, float y, float length) : base()
        {
            X = x;
            Y = y;
            _length = length;
        }
        public MyLine() : this(Color.Green, SplashKit.MouseX(), SplashKit.MouseY(), 100) { }

        public float Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        public override void Draw()         
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(Color.BrightGreen, X, Y, X + Length, Y);
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
            x: X+Length,
            y: Y,
            radius: 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X > X && pt.X < X + Length && pt.Y == Y;
        }
    }
}
