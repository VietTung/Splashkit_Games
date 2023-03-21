using System;
using SplashKitSDK;


class Bullet : SpriteItem
{
    public Bullet(){}

    public Bullet(string name):base(name)
    {
        SetLocation();
    }

    public override void SetLocation()
    {
        SplashKit.SpriteSetX(this.sprite, SplashKit.ScreenWidth());
        SplashKit.SpriteSetY(this.sprite, 0);              
    }

    public Bullet newBullet()
    {
        Bullet res = new Bullet("bullet_small.png");    
        return res;   
    }
}

