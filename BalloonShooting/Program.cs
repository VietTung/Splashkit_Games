using System;
using System.Collections.Generic;


public class BalloonShooting
{
    
    static    Func<int, float> movement = v => new Random().Next(v*5)*0.2f - 5;

    static void Main(string[] args)
    {
        List<Balloon> balloons = new List<Balloon>();            
        Cannon cannon = new Cannon().newCannon();

        Game game = new Game(cannon, balloons);

        int bal_num = new Random().Next(20) + 6;
        game.create_balloon(bal_num);

        game.start_game();


    }
}
