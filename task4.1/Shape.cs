using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;

        private float _x, _y;

        private bool _selected;

        public Shape(float x = 0, float y = 0)
        {
            _color = Color.Blue;
            _x = x;
            _y = y;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public Color Clr
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }
        public abstract void DrawOutline();
        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);
    }
}
