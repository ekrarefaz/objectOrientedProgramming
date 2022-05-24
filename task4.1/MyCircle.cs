using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private float _radius;

        private Color color;

        public MyCircle(Color Color, float x, float y, float radius=50) : base()
        {
            X = x;
            Y = y;
            _radius = radius;

        }

        public MyCircle() : this(Color.Yellow, 0, 0, 50)
        {

        }

        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Clr, X, Y, Radius);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(
                clr: Color.White,
                x: X,
                y: Y,
                radius: Radius + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            float dx = SplashKit.MouseX() - X;
            float dy = SplashKit.MouseY() - Y;
            return dx * dx + dy * dy <= Radius * Radius;
        }
    }
}
