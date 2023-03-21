// using System;
// using SplashKitSDK;

// public abstract class Sounds
// {
//     protected Window _gameWindow;

//     public abstract void Play();
// }

// public class BackGroundMusic : Sounds
// {

//     public BackGroundMusic(Window gameWindow)
//     {
//         _gameWindow = gameWindow;
//     }
//     public override void Play()
//     {
//         SoundEffect backGround = new SoundEffect("Elegy","Elegy.mp3");
//         backGround.Play(10, 0.2F);
//     }
// }