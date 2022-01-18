using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PangTutorial
{
    class GameBall : VisibleGameObject
    {
        private float _velocityBall;
        private float _angle;
        private float _elapsedTimeSinceStart;

        public GameBall()
        {

            _velocityBall = 150000.0f;
            _elapsedTimeSinceStart = 3.0f;
            Load(@"D:\PICTURES\ball.png");
            GetSprite().Origin = new SFML.System.Vector2f(15, 15);
            _angle = (float)Game.random.Next(0, 361);
            
        }

        override public void Update(float elapsedTime)
        {
            _elapsedTimeSinceStart += elapsedTime;
            //Console.WriteLine(_velocityBall);
            
            if (_elapsedTimeSinceStart < 3.0f)
            {
                return;
            }



             float moveAmount = _velocityBall * elapsedTime;
             float moveByX = LinearVelocityX(_angle) * moveAmount;
             float moveByY = LinearVelocityY(_angle) * moveAmount;


             //collide with the left side of the screen

             if (GetPosition().X + moveByX <= 0 + GetWidth()/2 || GetPosition().X + GetHeight()/2 + moveByX >= Game.SCREEN_WIDTH)
             {
                 //Ricochet!
                 _angle = 360.0f - _angle;

                 if (_angle > 260.0f && _angle < 280.0f)
                 {
                     _angle += 20.0f;
                 }
                 if (_angle > 80.0f && _angle < 100.0f)
                 {
                     _angle += 20.0f;
                 }

                 moveByX = -moveByX;

             }

             PlayerPaddle player1 = (PlayerPaddle)Game._gameObjectManager.Get("Paddle1");
             AiPaddle player2 = (AiPaddle)Game._gameObjectManager.Get("Paddle2");

            if (player1 != null)
             {
                 FloatRect p1BB = player1.GetBoundingRect();

                 if(p1BB.Intersects(GetBoundingRect()))
                 {
                    //ServiceLocator.GetAudio().PlaySound(@"D:\PICTURES\big ass\moan2.flac");
                    _angle = 360.0f - (_angle - 180.0f);

                     if (_angle > 360.0f)
                     {
                         _angle -= 360.0f;
                     }

                     moveByY = -moveByY;

                     // Make sure ball isn't inside paddle

                     if (GetBoundingRect().Height > player1.GetBoundingRect().Top)
                     {
                         SetPosition(GetPosition().X, player1.GetBoundingRect().Top - GetWidth()/2 - 1);
                     }

                     // Now add "English" based on the players velocity.  
                     float playerVelocity = player1.GetVelocity();

                     if (playerVelocity < 0)
                     {
                         //left
                         _angle -= 20.0f;

                         if (_angle < 0)
                         {
                             _angle = 360.0f - _angle;
                         }
                     }
                     else if (playerVelocity > 0)
                     {
                         _angle += 20.0f;

                         if (_angle > 360.0f)
                         {
                             _angle = _angle - 360.0f;
                         }

                     }

                     _velocityBall += 5.0f;

                 }

                 if (GetPosition().Y - GetHeight()/2 <= 0)
                 {
                     _angle = 180 - _angle;
                     moveByY = -moveByY;
                 }

                 if (GetPosition().Y + GetHeight()/2 + moveByY >= Game.SCREEN_HEIGHT )
                 {
                     // move to middle of the screen for now and randomize angle

                     GetSprite().Position = new SFML.System.Vector2f(Game.SCREEN_WIDTH / 2, Game.SCREEN_HEIGHT / 2);
                     _angle = (float)Game.random.Next(0, 361);
                     _velocityBall = 150000.0f;
                     _elapsedTimeSinceStart = 3.0f;
                 }

                 

                 GetSprite().Position += new SFML.System.Vector2f(moveByX, moveByY);

             }


            if (player2 != null)
            {
                FloatRect p2BB = player2.GetBoundingRect();

                if (p2BB.Intersects(GetBoundingRect()))
                {
                    //ServiceLocator.GetAudio().PlaySound(@"D:\PICTURES\big ass\moan2.flac");
                    _angle = 360.0f - (_angle - 180.0f);

                    if (_angle > 360.0f)
                    {
                        _angle -= 360.0f;
                    }

                    moveByY = -moveByY;

                    // Make sure ball isn't inside paddle

                    if (GetBoundingRect().Height > player2.GetBoundingRect().Width)
                    {
                        SetPosition(GetPosition().X, player2.GetBoundingRect().Width - GetWidth() / 2 - 1);
                    }

                    // Now add "English" based on the players velocity.  
                    float playerVelocity2 = player2.GetVelocity();

                    if (playerVelocity2 < 0)
                    {
                        //left
                        _angle -= 20.0f;

                        if (_angle < 0)
                        {
                            _angle = 360.0f - _angle;
                        }
                    }
                    else if (playerVelocity2 > 0)
                    {
                        _angle += 20.0f;

                        if (_angle > 360.0f)
                        {
                            _angle = _angle - 360.0f;
                        }

                    }

                    _velocityBall += 5.0f;

                }

                if (GetPosition().Y - GetHeight() / 2 <= 0)
                {
                    _angle = 180 - _angle;
                    moveByY = -moveByY;
                }

                if (GetPosition().Y + GetHeight() / 2 + moveByY >= Game.SCREEN_HEIGHT)
                {
                    // move to middle of the screen for now and randomize angle

                    GetSprite().Position = new SFML.System.Vector2f(Game.SCREEN_WIDTH / 2, Game.SCREEN_HEIGHT / 2);
                    _angle = (float)Game.random.Next(0, 361);
                    _velocityBall = 150000.0f;
                    _elapsedTimeSinceStart = 3.0f;
                }



                GetSprite().Position += new SFML.System.Vector2f(moveByX, moveByY);

            }



        }


        private float LinearVelocityX(float angle)
        {
            angle -= 90;
            if (angle < 0)
            {
                angle = 360 + angle;
            }

            return (float)Math.Cos(angle * (Math.PI / 180.0f));
        }

        private float LinearVelocityY(float angle)
        {
            angle -= 90;
            if (angle < 0)
            {
                angle = 360 + angle;
            }

            return (float)Math.Sin(angle * (Math.PI / 180.0f));
        }

    }
}
