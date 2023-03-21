using System;
using SplashKitSDK;
using System.Collections.Generic;

public class RobotDodge
{

    public Player _player;

    private Window _gameWindow;
    private static List<Bullet> _Bullets = new List<Bullet>();
    private static List<Robot> _Robots = new List<Robot>();


    public Timer gameTime = new Timer("Game Timer");
    public bool Quit
    {
        get
        {
            return _player.Quit;
        }
    }

    public RobotDodge(Window gameWindow)
    {
        _gameWindow = gameWindow;

        _player = new Player(_gameWindow);
        RandomRobot(_gameWindow, _player);

        gameTime.Start();


    }
    public void HandleInput()
    {
        _player.HandleInput();
        _player.StayOnWindow(_gameWindow);


        if (SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            _Bullets.Add(FireBullet(_gameWindow, _player));
        }
        SplashKit.ProcessEvents();
    }
    public void Update()
    {
        CheckCollisions();
        _player.UpdateHealth();

        for (int i = 0; i < _Robots.Count; i++)
        {
            _Robots[i].Update();
        }
        for (int i = 0; i < _Bullets.Count; i++)
        {
            _Bullets[i].Update();
        }

        if (SplashKit.Rnd(500) < 10)
            _Robots.Add(RandomRobot(_gameWindow, _player));
    }

    private void CheckCollisions()
    {
        List<Robot> _removedRobots = new List<Robot>();
        List<Bullet> _removedBullets = new List<Bullet>();

        PlayerCollision(_removedRobots);
        BulletCollision(_removedBullets, _removedRobots);
    }

    private void PlayerCollision(List<Robot> _removedRobots)
    {
        for (int i = 0; i < _Robots.Count; i++)
        {
            if (_player.CollidedWith(_Robots[i]) || _Robots[i].IsOffScreen(_gameWindow))
            {
                _removedRobots.Add(_Robots[i]);
            }
        }
        for (int i = 0; i < _removedRobots.Count; i++)
        {
            _Robots.Remove(_removedRobots[i]);
        }
    }
    private void OffSceen()
    {

    }
    private void BulletCollision(List<Bullet> _removedBullets, List<Robot> _removedRobots)
    {
        for (int i = 0; i < _Bullets.Count; i++)
        {
            for (int j = 0; j < _Robots.Count; j++)
            {
                if (_Bullets[i].CollidedWith(_Robots[j]))
                {
                    _removedBullets.Add(_Bullets[i]);
                    _removedRobots.Add(_Robots[j]);
                }
                if (_Bullets[i].IsOffScreen(_gameWindow))
                {
                    _removedBullets.Add(_Bullets[i]);
                }
            }
        }
        for (int i = 0; i < _removedBullets.Count; i++)
        {
            _Bullets.Remove(_removedBullets[i]);
        }
        for (int i = 0; i < _removedRobots.Count; i++)
        {
            _Robots.Remove(_removedRobots[i]);
        }

    }
    public void Draw()
    {
        _gameWindow.Clear(Color.White);
        
        Score();
        for (int i = 0; i < _Bullets.Count; i++)
        {
            _Bullets[i].Draw();
        }
        for (int i = 0; i < _Robots.Count; i++)
        {
            _Robots[i].Draw();
        }
        
        _player.Draw();
        _player.DrawHealth(_gameWindow);
        _gameWindow.Refresh(60);

    }
    public void Score()
    {
        uint score = SplashKit.TimerTicks(gameTime)/1000;

        string testS = score.ToString();

        SplashKit.DrawTextOnWindow(_gameWindow, testS, Color.Black, 5, 0);
    }

    public Robot RandomRobot(Window _gameWindow, Player _player)
    {
        if (SplashKit.Rnd() < 0.5)
            return new Roundy(_gameWindow, _player);
        else
            return new Boxy(_gameWindow, _player);
    }

    public Bullet FireBullet(Window _gameWindow, Player _player)
    {
        return new Bullet(_gameWindow, _player);
    }
}