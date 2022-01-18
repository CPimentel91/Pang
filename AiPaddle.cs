using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PangTutorial
{
    class AiPaddle : VisibleGameObject
    {
        public AiPaddle()
        {
            _velocity = 0;
            _maxVelocity = 600.0f;
            Load(@"D:\PICTURES\paddle.png");
            GetSprite().Origin = new SFML.System.Vector2f(GetSprite().Texture.Size.X / 2, GetSprite().Texture.Size.Y / 2);
        }

        override public void Update(float elapsedTime)
        {
            GameBall gameBall = (GameBall)Game._gameObjectManager.Get("Ball");
            Vector2f ballPosition = gameBall.GetPosition();
            

            if (GetPosition().X - 20 < ballPosition.X)
            {
                _velocity += 15.0f;
            }
            else if (GetPosition().X + 20 > ballPosition.X)
            {
                _velocity -= 10.0f;
            }
            else
            {
                _velocity = 0.0f;
            }

            
            if (_velocity > _maxVelocity)
            {
                _velocity = _maxVelocity;
            }
               
            if (_velocity < -_maxVelocity)
            {
                _velocity = -_maxVelocity;
            }
            
            Vector2f pos = this.GetPosition();
            if (pos.X <= GetSprite().Texture.Size.X / 2 || pos.X >= (Game.SCREEN_WIDTH - GetSprite().Texture.Size.X / 2))
            {
                _velocity = -_velocity * 100; // Bounce by current velocity in opposite direction
            }

            GetSprite().Position += new Vector2f(_velocity * (elapsedTime * 500), 0);
        }

        public void Draw(RenderWindow renderWindow)
        {
            Draw(renderWindow);
        }

        public float GetVelocity()
        {
            return _velocity;
        }

        private float _velocity; 
        private float _maxVelocity;
    }
}
