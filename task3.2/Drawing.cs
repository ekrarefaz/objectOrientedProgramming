using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        //private readonly int ShapeCount;
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;

        }
        public Color Background
        {
            set
            {
                _background = value;
            }
        }
        public Drawing () : this (Color.White)
        {

        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
        public void SelectedShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }
                return result;
            }
        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape s in _shapes)
            {
                s.Draw();
            }
        }
    }
}
