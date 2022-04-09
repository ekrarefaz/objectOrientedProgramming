using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Drawing drawing = new Drawing();
            new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = new Shape(SplashKit.MouseX(), SplashKit.MouseY());
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
                    foreach (Shape s in drawing.SelectedShapes)
                        drawing.RemoveShape(s);
                }
                //Console.WriteLine("Drawing");
                drawing.Draw();
                SplashKit.RefreshScreen();
            }while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
