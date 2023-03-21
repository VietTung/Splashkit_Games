using System;
using SplashKitSDK;

public class Bullet
{

    public double _X { get; private set; }
    public double _Y { get; private set; }

    public int Radius
    {
        get { return 10; }
    }

    private const int SPEED = 5;
    private Vector2D Velocity { get; set; }

    public Color BulletColor { get; set; }

    public Circle CollisionCircle
    {
        get { return SplashKit.CircleAt(_X, _Y, Radius); }
    }

    public Bullet(Window gameWindow, Player player)
    {
        _X = player.X + player.Width / 2;
        _Y = player.Y + player.Height / 2;

        BulletColor = Color.DarkRed;

        Point2D fromPt = new Point2D()
        {
            X = _X,
            Y = _Y
        };

        Point2D toPt = SplashKit.MousePosition();

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        Velocity = SplashKit.VectorMultiply(dir, SPEED);
    }

    public void Update()
    {
        _X += Velocity.X;
        _Y += Velocity.Y;
    }

    public void Draw()
    {
        SplashKit.FillCircle(BulletColor, _X, _Y, Radius);
    }

    public bool CollidedWith(Robot robot)
    {
        return SplashKit.CirclesIntersect(CollisionCircle, robot.CollissionCircle);
    }

    public bool IsOffScreen(Window gameWindow)
    {
        return (_X < -Radius || _X > gameWindow.Width || _Y < -Radius || _Y > gameWindow.Height);
    }
}