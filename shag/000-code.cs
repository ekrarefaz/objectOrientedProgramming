using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            ShapeKind kindToAdd;
            Drawing drawing = new Drawing();
            new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if(SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                    Console.WriteLine("Shape Change C");

                }
                else if(SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                    Console.WriteLine("Shape Change R");
                }
                else if(SplashKit.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                    Console.WriteLine("Shape Change L");

                }
                else
                {
                    kindToAdd = ShapeKind.Rectangle; 
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if(kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }
                    else
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }
                    drawing.AddShape(newShape);
                    Console.WriteLine("Adding");
                }
                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectedShapesAt(SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    drawing.SelectedShapesAt(SplashKit.MousePosition());
                    drawing.Delete(drawing.SelectedShapes);
                }
                drawing.Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
