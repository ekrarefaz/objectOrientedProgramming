﻿using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;
        

        public Shape(float x=0, float y=0)
        {
            _color = Color.Blue;
            _x = x;
            _y = y;
            _width = 100;
            _height = 100;
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
        public void DrawOutline(Color _bordercolor)
        {
            
            SplashKit.FillRectangle(Color.Red, X - 2, Y - 2, Width + 10, Height + 10);
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            if (pt.X > this.X && pt.Y < this.X + this._width && pt.Y > this.Y && pt.Y < this.Y + this._height)
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