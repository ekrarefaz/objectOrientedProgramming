using System;
using SplashKitSDK;

namespace ShapeDrawer
{

    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color Color, float x, float y, int width=100, int height=100) : base()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(Color.Red, X, Y, Width, Height);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(
                clr: Color.White,
                x: (X - 2),
                y: (Y - 2),
                width: (Width + 6),
                height: (Height + 6)
                );
        }
        public override bool IsAt(Point2D pt)
        {
            if (pt.X > this.X && pt.X < this.X + this._width && pt.Y > this.Y && pt.Y < this.Y + this._height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
