using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("Robot Dodge!", 800, 600);
        RobotDodge robotDodge = new RobotDodge(gameWindow);

        while (!SplashKit.QuitRequested() && !robotDodge.Quit)
        {
            SplashKit.ProcessEvents();
            robotDodge.HandleInput();
            robotDodge.Update();
            robotDodge.Draw();        
        }
    }
}   