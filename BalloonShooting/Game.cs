using System;
using SplashKitSDK;
using System.Collections.Generic;


class Game
{

    private bool is_game_playing;
    const string WON = "YOU WON!";
    const string LOSE = "YOU LOSE!";
    const string NUM_SHOTS = "Number of shots used: ";
    const string QUIT = "Press Q to quit, or R to play again";
    private Cannon _cannon;
    private List<Balloon> _balloons;

    public Game(Cannon cannon,List<Balloon> balloons)
    {
        _cannon = cannon;
        _balloons = balloons;
    }

    void load_resources()
    {
        SplashKit.LoadResourceBundle("game_bundle", "balloon-shooting.txt");
        SplashKit.LoadFont("game_font","Misti_Nicole.ttf");
    }

    private void quit_query()
    {   
        is_game_playing = false;
        SplashKit.ClearScreen(Color.White);
        SplashKit.DrawBitmap(SplashKit.BitmapNamed("blue_sky"),0,0);
        double center_x = SplashKit.CurrentWindowWidth() / 2;
        double center_y = SplashKit.CurrentWindowHeight() / 2;
        if (_balloons.Count == 0){
            string shots = NUM_SHOTS + (5 - _cannon.Shots()).ToString();
            SplashKit.DrawText(WON, Color.Black, "game_font", 40, center_x - SplashKit.TextWidth(WON,"game_font",40)/2, center_y - 80);
            SplashKit.DrawText(shots,Color.Black, "game_font", 18, center_x - SplashKit.TextWidth(shots,"game_font",18)/2, center_y-20);
            SplashKit.DrawText(QUIT,Color.Black, "game_font", 14, center_x - SplashKit.TextWidth(QUIT,"game_font",14)/2, center_y + 80);
        } else{
            SplashKit.DrawText(LOSE,Color.Black, "game_font", 40, center_x - SplashKit.TextWidth(WON,"game_font",40)/2, center_y - 30);
            SplashKit.DrawText(QUIT,Color.Black, "game_font", 14, center_x - SplashKit.TextWidth(QUIT,"game_font",14)/2, center_y + 30);
        }
        
        if (SplashKit.KeyDown(KeyCode.QKey)){
            System.Environment.Exit(1);
        } else if (SplashKit.KeyDown(KeyCode.RKey)){
            is_game_playing = true;
            SplashKit.FreeAllSprites();
            _cannon = new Cannon().newCannon();
            _balloons = new List<Balloon>();
            create_balloon(new Random().Next(20) + 6);
        }
    }


    private List<T> clone<T>(T Subject, int num)
    {
        List<T> res = new List<T>();
        for (int i = 0; i < num; i++){
            res.Add(Subject);
        }
        return res;
    }

    public void create_balloon(int _bal_num){
        //_balloons = clone<Balloon>(new Balloon().new_balloon(), _bal_num);
        for (int i = 0; i < _bal_num; i++){
            _balloons.Add(new Balloon().new_balloon());
        }
        
    }

    public void start_game(){
        is_game_playing = true;
        Console.WriteLine(_balloons);
        Console.WriteLine(_cannon);
        SplashKit.OpenWindow("Balloon Shooting games", 800, 600);
        load_resources();
        Bitmap background = SplashKit.BitmapNamed("blue_sky");
        while (!SplashKit.QuitRequested())
        {
            SplashKit.ProcessEvents();
            if (is_game_playing){
                _cannon.handle_input();
                for (int i = 0; i < _balloons.Count; i++){
                    _balloons[i].update_sprite();
                }
                _cannon.update_player();
            }

            SplashKit.ClearScreen(Color.White);
            SplashKit.DrawBitmap(background,0,0);
            SplashKit.DrawText("Shots: " + (_cannon.Shots()), Color.Black, "game_font",20, 0, 580);
            
            _cannon.draw_sprite();

            for (int i = 0; i < _balloons.Count; i++)
            {
                _balloons[i].draw_sprite();
                if (SplashKit.SpriteCollision(_balloons[i].getSprite(),_cannon.bullet.getSprite())){
                    _cannon.setScore(_cannon.Score()+1);
                    _balloons.RemoveAt(i);
                }
            }

            if (_balloons.Count == 0 | _cannon.Shots() <= 0){
                quit_query();
            }
            
            SplashKit.RefreshScreen(60);
        }
        
    }

}
