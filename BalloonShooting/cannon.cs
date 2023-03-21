using System;
using SplashKitSDK;


class Cannon : SpriteItem
{
    public Bullet bullet =  new Bullet().newBullet();
    private int score, shots;
    private bool is_fired;

    public const int C_spd = 5;
    public const int B_spd = 5;

    public Cannon(){}
    public Cannon(string name, int score, int shots, bool is_fired):base(name)
    {

        this.score   = score;
        this.shots   = shots;
        this.is_fired = is_fired;   

        SetLocation();
    }

    public int Score(){
        return score;
    }

    public int Shots(){
        return shots;
    }

    public void setScore(int _score){
        this.score = _score;
    }

    public void setShots(int _shots){
        this.shots = _shots;
    }



    public override void SetLocation()
    {
        SplashKit.SpriteSetX(this.sprite, SplashKit.ScreenWidth()-this.width);
        SplashKit.SpriteSetY(this.sprite, 300);
    }

    public void shoot()
    {
    //Position the bullet
        Point2D c_location = SplashKit.SpritePosition(this.sprite);
        SplashKit.SpriteSetX(this.bullet.getSprite(), float.Parse((c_location.X - this.bullet.getWidth()).ToString()));
        SplashKit.SpriteSetY(this.bullet.getSprite(), float.Parse((c_location.Y + this.width*0.18).ToString()));
    //Shoot the bullet
        SplashKit.SpriteSetDx(this.bullet.getSprite(), -B_spd);
    }

    public override void draw_sprite()
    {
        SplashKit.DrawSprite(this.sprite);
        SplashKit.DrawSprite(this.bullet.getSprite());

    }

    public void update_player()
    {
        SplashKit.UpdateSprite(this.sprite);
        SplashKit.UpdateSprite(this.bullet.getSprite());
    //Prevent the cannon pass through wall 
        Point2D c_location = SplashKit.SpritePosition(this.sprite);
        if (c_location.X < 0 | c_location.Y > 600-this.height)
        {
            SplashKit.SpriteSetDy(this.sprite, 0);
        }
    //Move the bullet back when it reach the wall
        double b_x = SplashKit.SpriteX(this.bullet.getSprite());
        if (b_x < -this.bullet.getWidth()){
            this.shots--;
            this.is_fired = false;
            SplashKit.SpriteSetDx(this.bullet.getSprite(),0);  
            SplashKit.SpriteSetX(this.bullet.getSprite(), SplashKit.ScreenWidth());
            SplashKit.SpriteSetY(this.bullet.getSprite(), 0);
        }
    }
    public void handle_input(){

    //Cannon's movement

        Point2D c_location = SplashKit.SpritePosition(this.sprite);

        if ((SplashKit.KeyTyped(KeyCode.UpKey)) & (c_location.Y > 0 ))
            SplashKit.SpriteSetDy(this.sprite, -C_spd);

        if ((SplashKit.KeyTyped(KeyCode.DownKey)) & (c_location.Y < SplashKit.ScreenHeight()- this.height))
            SplashKit.SpriteSetDy(this.sprite, C_spd);

        if (SplashKit.KeyReleased(KeyCode.UpKey) | SplashKit.KeyReleased(KeyCode.DownKey))
            SplashKit.SpriteSetDy(this.sprite, 0);

        if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            if (!this.is_fired) {
                this.is_fired = true;
                shoot();
        }

    }

    public Cannon newCannon()
    {
        Cannon res = new Cannon("cannon_small.png", 0, 5, false);
        bullet = new Bullet().newBullet();
        return res;
    }
}

