using System;
using SplashKitSDK;


abstract class SpriteItem: ISpriteItem
{
    protected Sprite sprite;

    protected int width, height;

    public int getWidth(){
        return this.width;
    }

    public int getHeight(){
        return this.height;
    }

    public Sprite getSprite(){
        return this.sprite;
    }

    public SpriteItem(){}

    public SpriteItem(string name)
    {
        Bitmap bmp = SplashKit.BitmapNamed(name);   
        this.sprite  = SplashKit.CreateSprite(bmp);
        this.width   = SplashKit.SpriteWidth(this.sprite);
        this.height  = SplashKit.SpriteHeight(this.sprite); 
        
    }

    public virtual void SetLocation() 
    {
        SplashKit.SpriteSetX(this.sprite, SplashKit.ScreenWidth());
        SplashKit.SpriteSetY(this.sprite, 0);  
    }

    public virtual void draw_sprite()
    {
        SplashKit.DrawSprite(this.sprite);
    }

    public virtual void update_sprite()
    {
        SplashKit.UpdateSprite(this.sprite);        
    }

}


