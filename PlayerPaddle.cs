using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PangTutorial
{
    class PlayerPaddle : VisibleGameObject
    {
        public PlayerPaddle()
        {
            _velocity = 0;
            _maxVelocity = 600.0f;
            Load(@"D:\PICTURES\paddle.png");
            GetSprite().Origin = new SFML.System.Vector2f(GetSprite().Texture.Size.X / 2, GetSprite().Texture.Size.Y / 2);
        }

        override public void Update(float elapsedTime)
        {

        SFML.System.Vector2f pos = this.GetPosition();

            if (pos.X < GetSprite().Texture.Size.X/2 || pos.X > (Game.SCREEN_WIDTH - GetSprite().Texture.Size.X/2))
            {
                _velocity = -_velocity;
            }

            GetSprite().Position += new SFML.System.Vector2f(_velocity * elapsedTime, 0);
        }

        public void Draw(RenderWindow renderWindow)
        {
            Draw(renderWindow);
        }

        public float GetVelocity()
        {
            return _velocity;
        }

        public float _velocity;
        public float _maxVelocity;
    }
}
