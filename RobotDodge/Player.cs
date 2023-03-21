using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;
    private Bitmap _HeartBitmap;

    public double X { get; private set; }
    public double Y { get; private set; }

    public bool Quit { get; private set; }

    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }

    public int health;
    public Player(Window gameWindow)
    {
        _PlayerBitmap = new Bitmap("player", "Player.png");
        _HeartBitmap = new Bitmap("heart", "heart.png");
        X = (gameWindow.Width / 2) - _PlayerBitmap.Width / 2;
        Y = (gameWindow.Height / 2) - _PlayerBitmap.Height / 2;
        Quit = false;
        health = 5;
    }

    public void Draw()
    {
        _PlayerBitmap.Draw(X, Y);        
    }

    public void HandleInput()
    {
        const int SPEED = 5;

        
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.EscapeKey)
        )
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window gameWindow)
    {
        const int GAP = 10;

        if (X < GAP)
        {
            X = GAP;
        }
        if (X + _PlayerBitmap.Width > gameWindow.Width - GAP)
        {
            X = gameWindow.Width - GAP - _PlayerBitmap.Width;
        }
        if (Y < GAP)
        {
            Y = GAP;
        }
        if (Y + _PlayerBitmap.Height > gameWindow.Height - GAP)
        {
            Y = gameWindow.Height - GAP - _PlayerBitmap.Height;
        }
    }

    public bool CollidedWith(Robot robot)
    {
        bool collide = _PlayerBitmap.CircleCollision(X, Y, robot.CollissionCircle);    

        if (collide)
        {
            health--;
        }
        return collide;    
    }


    public void DrawHealth(Window gameWindow)
    {
        int heart_y = 20;
        int x_offset = 20;
        for (int i = 1; i <= health; i++)
        {
            _HeartBitmap.Draw(gameWindow.Width - (_HeartBitmap.Width * i + x_offset * i), heart_y);
        }
    }
    public void UpdateHealth()
    {
        if (health == 0) 
            Quit = true;
    }
}