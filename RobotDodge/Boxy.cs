// using System;
// using SplashKitSDK;

// public class Boxy : Robot
// {
//     public Boxy(Window gameWindow, Player player) : base(gameWindow, player)
//     {

//     }
//     public override void Draw()
//     {
//         double leftX, rightX, eyeY, mouthY;
//         leftX = X + 12;
//         rightX = X + 27;
//         eyeY = Y + 10;
//         mouthY = Y + 30;

//         SplashKit.FillRectangle(Color.Gray, X, Y, Width, Height);
//         SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
//         SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
//         SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
//         SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);
//     }
// }