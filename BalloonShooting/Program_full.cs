//------------Program.cs-----------------
// using System;
// using System.Collections.Generic;


// public class BalloonShooting
// {
    
//     static    Func<int, float> movement = v => new Random().Next(v*5)*0.2f - 5;

//     static void Main(string[] args)
//     {
//         List<Balloon> balloons = new List<Balloon>();            
//         Cannon cannon = new Cannon().newCannon();

//         Game game = new Game(cannon, balloons);

//         int bal_num = new Random().Next(20) + 6;
//         game.create_balloon(bal_num);

//         game.start_game();


//     }
// }

// ----------Game.cs----------------
// using System;
// using SplashKitSDK;
// using System.Collections.Generic;


// class Game
// {

//     private bool is_game_playing;
//     const string WON = "YOU WON!";
//     const string LOSE = "YOU LOSE!";
//     const string NUM_SHOTS = "Number of shots used: ";
//     const string QUIT = "Press Q to quit, or R to play again";
//     private Cannon _cannon;
//     private List<Balloon> _balloons;

//     public Game(Cannon cannon,List<Balloon> balloons)
//     {
//         _cannon = cannon;
//         _balloons = balloons;
//     }

//     void load_resources()
//     {
//         SplashKit.LoadResourceBundle("game_bundle", "balloon-shooting.txt");
//         SplashKit.LoadFont("game_font","Misti_Nicole.ttf");
//     }

//     private void quit_query()
//     {   
//         is_game_playing = false;
//         SplashKit.ClearScreen(Color.White);
//         SplashKit.DrawBitmap(SplashKit.BitmapNamed("blue_sky"),0,0);
//         double center_x = SplashKit.CurrentWindowWidth() / 2;
//         double center_y = SplashKit.CurrentWindowHeight() / 2;
//         if (_balloons.Count == 0){
//             string shots = NUM_SHOTS + (5 - _cannon.Shots()).ToString();
//             SplashKit.DrawText(WON, Color.Black, "game_font", 40, center_x - SplashKit.TextWidth(WON,"game_font",40)/2, center_y - 80);
//             SplashKit.DrawText(shots,Color.Black, "game_font", 18, center_x - SplashKit.TextWidth(shots,"game_font",18)/2, center_y-20);
//             SplashKit.DrawText(QUIT,Color.Black, "game_font", 14, center_x - SplashKit.TextWidth(QUIT,"game_font",14)/2, center_y + 80);
//         } else{
//             SplashKit.DrawText(LOSE,Color.Black, "game_font", 40, center_x - SplashKit.TextWidth(WON,"game_font",40)/2, center_y - 30);
//             SplashKit.DrawText(QUIT,Color.Black, "game_font", 14, center_x - SplashKit.TextWidth(QUIT,"game_font",14)/2, center_y + 30);
//         }
        
//         if (SplashKit.KeyDown(KeyCode.QKey)){
//             System.Environment.Exit(1);
//         } else if (SplashKit.KeyDown(KeyCode.RKey)){
//             is_game_playing = true;
//             SplashKit.FreeAllSprites();
//             _cannon = new Cannon().newCannon();
//             _balloons = new List<Balloon>();
//             create_balloon(new Random().Next(20) + 6);
//         }
//     }


//     private List<T> clone<T>(T Subject, int num)
//     {
//         List<T> res = new List<T>();
//         for (int i = 0; i < num; i++){
//             res.Add(Subject);
//         }
//         return res;
//     }

//     public void create_balloon(int _bal_num){
//         //_balloons = clone<Balloon>(new Balloon().new_balloon(), _bal_num);
//         for (int i = 0; i < _bal_num; i++){
//             _balloons.Add(new Balloon().new_balloon());
//         }
        
//     }

//     public void start_game(){
//         is_game_playing = true;
//         Console.WriteLine(_balloons);
//         Console.WriteLine(_cannon);
//         SplashKit.OpenWindow("Balloon Shooting games", 800, 600);
//         load_resources();
//         Bitmap background = SplashKit.BitmapNamed("blue_sky");
//         while (!SplashKit.QuitRequested())
//         {
//             SplashKit.ProcessEvents();
//             if (is_game_playing){
//                 _cannon.handle_input();
//                 for (int i = 0; i < _balloons.Count; i++){
//                     _balloons[i].update_sprite();
//                 }
//                 _cannon.update_player();
//             }

//             SplashKit.ClearScreen(Color.White);
//             SplashKit.DrawBitmap(background,0,0);
//             SplashKit.DrawText("Shots: " + (_cannon.Shots()), Color.Black, "game_font",20, 0, 580);
            
//             _cannon.draw_sprite();

//             for (int i = 0; i < _balloons.Count; i++)
//             {
//                 _balloons[i].draw_sprite();
//                 if (SplashKit.SpriteCollision(_balloons[i].getSprite(),_cannon.bullet.getSprite())){
//                     _cannon.setScore(_cannon.Score()+1);
//                     _balloons.RemoveAt(i);
//                 }
//             }

//             if (_balloons.Count == 0 | _cannon.Shots() <= 0){
//                 quit_query();
//             }
            
//             SplashKit.RefreshScreen(60);
//         }
        
//     }

// }


// ------Balloon.cs--------
// using System;
// using SplashKitSDK;


// class Balloon : SpriteItem
// {
//     private float bal_dx, bal_dy;

//     public Balloon(){}

//     public Balloon(string name): base(name){}

//     Func<int, float> movement = v => new Random().Next(v*5)*0.2f - 5;

//     public Balloon new_balloon()
//     {   
//         this.sprite = SplashKit.CreateSprite("balloon_small.png");
//         this.height = SplashKit.SpriteHeight(this.sprite);
//         this.width  = SplashKit.SpriteWidth(this.sprite);

//         this.bal_dx = movement(5);
//         this.bal_dy = movement(5);
        
//         SplashKit.SpriteSetDx(this.sprite, this.bal_dx);
//         SplashKit.SpriteSetDy(this.sprite, this.bal_dy); 
//         SplashKit.SpriteSetX(this.sprite, 0);
//         SplashKit.SpriteSetY(this.sprite, 0);

//         return this;
//     }

//     private void bounce_from_wall()
//     {
//         Point2D bal_location = SplashKit.SpritePosition(this.sprite);

//         if (bal_location.X < 0 | bal_location.X > 600)
//             this.bal_dx *= -1;
//         if (bal_location.Y < 0 | bal_location.Y > 600 - this.height)
//             this.bal_dy *= -1;
//         SplashKit.SpriteSetDx(this.sprite, this.bal_dx);
//         SplashKit.SpriteSetDy(this.sprite, this.bal_dy);
//     }

//     public override void update_sprite()
//     {
//         SplashKit.UpdateSprite(this.sprite);    
//         bounce_from_wall();
//     }

// }

//-----------Canon.cs-------------
// using System;
// using SplashKitSDK;


// class Cannon : SpriteItem
// {
//     public Bullet bullet =  new Bullet().newBullet();
//     private int score, shots;
//     private bool is_fired;

//     public const int C_spd = 5;
//     public const int B_spd = 5;

//     public Cannon(){}
//     public Cannon(string name, int score, int shots, bool is_fired):base(name)
//     {

//         this.score   = score;
//         this.shots   = shots;
//         this.is_fired = is_fired;   

//         SetLocation();
//     }

//     public int Score(){
//         return score;
//     }

//     public int Shots(){
//         return shots;
//     }

//     public void setScore(int _score){
//         this.score = _score;
//     }

//     public void setShots(int _shots){
//         this.shots = _shots;
//     }



//     public override void SetLocation()
//     {
//         SplashKit.SpriteSetX(this.sprite, SplashKit.ScreenWidth()-this.width);
//         SplashKit.SpriteSetY(this.sprite, 300);
//     }

//     public void shoot()
//     {
//     //Position the bullet
//         Point2D c_location = SplashKit.SpritePosition(this.sprite);
//         SplashKit.SpriteSetX(this.bullet.getSprite(), float.Parse((c_location.X - this.bullet.getWidth()).ToString()));
//         SplashKit.SpriteSetY(this.bullet.getSprite(), float.Parse((c_location.Y + this.width*0.18).ToString()));
//     //Shoot the bullet
//         SplashKit.SpriteSetDx(this.bullet.getSprite(), -B_spd);
//     }

//     public override void draw_sprite()
//     {
//         SplashKit.DrawSprite(this.sprite);
//         SplashKit.DrawSprite(this.bullet.getSprite());

//     }

//     public void update_player()
//     {
//         SplashKit.UpdateSprite(this.sprite);
//         SplashKit.UpdateSprite(this.bullet.getSprite());
//     //Prevent the cannon pass through wall 
//         Point2D c_location = SplashKit.SpritePosition(this.sprite);
//         if (c_location.X < 0 | c_location.Y > 600-this.height)
//         {
//             SplashKit.SpriteSetDy(this.sprite, 0);
//         }
//     //Move the bullet back when it reach the wall
//         double b_x = SplashKit.SpriteX(this.bullet.getSprite());
//         if (b_x < -this.bullet.getWidth()){
//             this.shots--;
//             this.is_fired = false;
//             SplashKit.SpriteSetDx(this.bullet.getSprite(),0);  
//             SplashKit.SpriteSetX(this.bullet.getSprite(), SplashKit.ScreenWidth());
//             SplashKit.SpriteSetY(this.bullet.getSprite(), 0);
//         }
//     }
//     public void handle_input(){

//     //Cannon's movement

//         Point2D c_location = SplashKit.SpritePosition(this.sprite);

//         if ((SplashKit.KeyTyped(KeyCode.UpKey)) & (c_location.Y > 0 ))
//             SplashKit.SpriteSetDy(this.sprite, -C_spd);

//         if ((SplashKit.KeyTyped(KeyCode.DownKey)) & (c_location.Y < SplashKit.ScreenHeight()- this.height))
//             SplashKit.SpriteSetDy(this.sprite, C_spd);

//         if (SplashKit.KeyReleased(KeyCode.UpKey) | SplashKit.KeyReleased(KeyCode.DownKey))
//             SplashKit.SpriteSetDy(this.sprite, 0);

//         if (SplashKit.KeyTyped(KeyCode.SpaceKey))
//             if (!this.is_fired) {
//                 this.is_fired = true;
//                 shoot();
//         }

//     }

//     public Cannon newCannon()
//     {
//         Cannon res = new Cannon("cannon_small.png", 0, 5, false);
//         bullet = new Bullet().newBullet();
//         return res;
//     }
// }



//---------Bullet.cs----------
// using System;
// using SplashKitSDK;


// class Bullet : SpriteItem
// {
//     public Bullet(){}

//     public Bullet(string name):base(name)
//     {
//         SetLocation();
//     }

//     public override void SetLocation()
//     {
//         SplashKit.SpriteSetX(this.sprite, SplashKit.ScreenWidth());
//         SplashKit.SpriteSetY(this.sprite, 0);              
//     }

//     public Bullet newBullet()
//     {
//         Bullet res = new Bullet("bullet_small.png");    
//         return res;   
//     }
// }


//----------SpriteItem.cs------------
// using System;
// using SplashKitSDK;


// abstract class SpriteItem: ISpriteItem
// {
//     protected Sprite sprite;

//     protected int width, height;

//     public int getWidth(){
//         return this.width;
//     }

//     public int getHeight(){
//         return this.height;
//     }

//     public Sprite getSprite(){
//         return this.sprite;
//     }

//     public SpriteItem(){}

//     public SpriteItem(string name)
//     {
//         Bitmap bmp = SplashKit.BitmapNamed(name);   
//         this.sprite  = SplashKit.CreateSprite(bmp);
//         this.width   = SplashKit.SpriteWidth(this.sprite);
//         this.height  = SplashKit.SpriteHeight(this.sprite); 
        
//     }

//     public virtual void SetLocation() 
//     {
//         SplashKit.SpriteSetX(this.sprite, SplashKit.ScreenWidth());
//         SplashKit.SpriteSetY(this.sprite, 0);  
//     }

//     public virtual void draw_sprite()
//     {
//         SplashKit.DrawSprite(this.sprite);
//     }

//     public virtual void update_sprite()
//     {
//         SplashKit.UpdateSprite(this.sprite);        
//     }

// }

//---------ISpriteItem.cs---------
// using System;
// using SplashKitSDK;

// interface ISpriteItem
// {
//     void SetLocation(){}

//     void draw_sprite(){}

//     void update_sprite(){}

// }

