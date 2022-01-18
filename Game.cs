using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace PangTutorial
{
    static class Game
    {
        public static void Start()
        {
            if(_gameState != GameState.Unitialized)
            {
                return;
            }

            SFMLSoundProvider soundProvider = new SFMLSoundProvider();
            ServiceLocator.RegisterServiceLocator(soundProvider);
            _mainWindow = new RenderWindow(new SFML.Window.VideoMode(1024, 768, 32), "Pang!");
            _mainWindow.SetFramerateLimit(700);
            //set event handlers here
            _mainWindow.Closed += OnClose;
            _mainWindow.KeyPressed += OnKeyPressed;
            _gameState = GameState.Playing;
            player1.SetPosition((SCREEN_WIDTH / 2),700);
            player2.SetPosition((SCREEN_WIDTH / 2), 40);
            GameBall ball = new GameBall();
            ball.SetPosition((SCREEN_WIDTH / 2), (SCREEN_HEIGHT / 2) - 15);
            _gameObjectManager.Add("Paddle1", player1);
            _gameObjectManager.Add("Paddle2", player2);
            _gameObjectManager.Add("Ball", ball);

            while (!IsExiting())
            {
                GameLoop();
            }

            _mainWindow.Close();

        }

        private static bool IsExiting()
        {
            if(_gameState == GameState.Exiting)
            {
                return true;
            }
            else
                return false;
        }

        private static void GameLoop()
        {

            switch (_gameState)
            {

                case GameState.Playing:
                    {
                        _mainWindow.DispatchEvents();
                        _mainWindow.Clear(new Color(0, 0, 0));
                        _gameObjectManager.UpdateAll();
                        _gameObjectManager.DrawAll(_mainWindow);
                        _mainWindow.Display();
                        break;
                    }


            }
        }

        public static RenderWindow GetWindow()
        {
            return _mainWindow;
        }

        //public static SFML.Window.In

        public enum GameState 
        { 
            Unitialized, 
            ShowingSplash, 
            Paused, 
            ShowingMenu, 
            Playing, 
            Exiting 
        };
        
        public static GameState _gameState;
        private static RenderWindow _mainWindow;
        public static GameObjectManager _gameObjectManager = new GameObjectManager();
        static PlayerPaddle player1 = new PlayerPaddle();
        static AiPaddle player2 = new AiPaddle();
        public static int SCREEN_WIDTH = 1024;
        public static int SCREEN_HEIGHT = 764;
        public static Clock clock = new Clock();
        public static Random random = new Random();


        //eventhandler code
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            _gameState = GameState.Exiting;
            window.Close();
        }

        static void OnKeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            

            if (e.Code == Keyboard.Key.Left)
            {
                
                if (player1._velocity > 0)
                {
                    player1._velocity -= 1200.0f;
                }
                else
                {
                    player1._velocity -= 600.0f;
                }
                
                player1._velocity -= 600.0f;
                //
            }

            if (e.Code == Keyboard.Key.Right)
            {
                
                if (player1._velocity < 0)
                {
                    player1._velocity += 1200.0f;
                }
                else
                {
                    player1._velocity += 600.0f;
                }
                
                //player1._velocity += 600.0f;

            }

            if (e.Code == Keyboard.Key.Down)
            {
                player1._velocity = 0.0f;
            }

           
            if (player1._velocity > player1._maxVelocity)
            {
                player1._velocity = player1._maxVelocity;
            }

            if (player1._velocity < -player1._maxVelocity)
            {
                player1._velocity = -player1._maxVelocity;
            }

            

        }



        //may not be needed or cause problems
        /*
        static Game()
        {
            _gameState = GameState.Unitialized;
        }
        */
    }
}
