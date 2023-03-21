using System;
using SplashKitSDK;


class Balloon : SpriteItem
{
    private float bal_dx, bal_dy;

    public Balloon(){}

    public Balloon(string name): base(name){}

    Func<int, float> movement = v => new Random().Next(v*5)*0.2f - 5;

    public Balloon new_balloon()
    {   
        this.sprite = SplashKit.CreateSprite("balloon_small.png");
        this.height = SplashKit.SpriteHeight(this.sprite);
        this.width  = SplashKit.SpriteWidth(this.sprite);

        this.bal_dx = movement(5);
        this.bal_dy = movement(5);
        
        SplashKit.SpriteSetDx(this.sprite, this.bal_dx);
        SplashKit.SpriteSetDy(this.sprite, this.bal_dy); 
        SplashKit.SpriteSetX(this.sprite, 0);
        SplashKit.SpriteSetY(this.sprite, 0);

        return this;
    }

    private void bounce_from_wall()
    {
        Point2D bal_location = SplashKit.SpritePosition(this.sprite);

        if (bal_location.X < 0 | bal_location.X > 600)
            this.bal_dx *= -1;
        if (bal_location.Y < 0 | bal_location.Y > 600 - this.height)
            this.bal_dy *= -1;
        SplashKit.SpriteSetDx(this.sprite, this.bal_dx);
        SplashKit.SpriteSetDy(this.sprite, this.bal_dy);
    }

    public override void update_sprite()
    {
        SplashKit.UpdateSprite(this.sprite);    
        bounce_from_wall();
    }

}

