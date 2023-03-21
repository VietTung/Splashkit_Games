// using System;
// using System.Collections.Generic;
// using SplashKitSDK;

// public abstract class Hud
// {
//     protected Window _gameWindow;
//     private int _life = 10;

//     public Font font
//     {
//         get; set;
//     }

//     public int Life 
//     { 
//         get { return _life;}
//         set { _life = value;}
//     }

//     protected int X { get; set;}
//     protected int Y { get; set;}

//     // private Bitmap _bitmap;

//     // public Bitmap Bitmap
//     // {
//     //     get;
//     // }

//     public virtual void Draw()
//     {
//         int windowWidth = _gameWindow.Width;
//         _gameWindow.FillRectangle(Color.RGBAColor(10, 29, 49, 100), 0, 555, windowWidth, 50);
//     }
// }

// public class DisplayLife : Hud
// {
//     int _lives = 10;
//     public DisplayLife(Window gameWindow)
//     {
//         X = 670;
//         Y = 570;
//         _gameWindow = gameWindow;
//     }
//     public int Lives
//     {
//         get { return _lives;}
//         set { _lives = value;}
//     }
      
//     public override void Draw()
//     {
//         base.Draw();
//         // String Lives1 = Convert.ToString(Lives);
//         // _gameWindow.DrawText($"{Lives1}", Color.White, "StencilStd.otf", 20, 700, 570);
//         // _gameWindow.FillCircle(Color.Red, 765, 575, 10);
//         // //_gameWindow.FillRectangle(Color.RGBAColor(10,29,49,100), 650, 565, 210, 50);

//     }
// }

// public class DisplayScore : Hud
// {
//     public DisplayScore(Window gameWindow)
//     {
//         _gameWindow = gameWindow;
//     }


//     public override void Draw()
//     {
        
//         _gameWindow.DrawText("Score Here", Color.White, "StencilStd.otf", 20, 10, 570);

//     }
// }
