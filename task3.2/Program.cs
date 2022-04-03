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
                    drawing.SelectedShapesAt(SplashKit.MousePosition());
                    drawing.Delete(drawing.SelectedShapes);
                }
                //Console.WriteLine("Drawing");
                foreach (Shape s in drawing.SelectedShapes)
                {
                    //Console.WriteLine("Outline");
                    s.DrawOutline(Color.Red);
                }
                drawing.Draw();
                SplashKit.RefreshScreen();
            }while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
