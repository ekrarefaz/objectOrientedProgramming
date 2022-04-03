using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            new Window("Shape Drawer", 800, 600);
            var myShape = new Shape();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                if (myShape.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        //Access the _color field of the shape and randomise it.
                        myShape.Clr = SplashKit.RandomRGBColor(255);
                    }
                }
                myShape.Draw();
                SplashKit.RefreshScreen();
            } while(!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}


