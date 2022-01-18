using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PangTutorial
{
    class VisibleGameObject
    {

        private bool _isLoaded;
        private string _filename;
        private Sprite _sprite;
        private Texture _texture;



        public VisibleGameObject()
        {
            _isLoaded = false;
        }
        public virtual void Load(string filename)
        {
            _filename = filename;
            _texture = new Texture(filename);
            _sprite = new Sprite(_texture);
            _isLoaded = true;
        }

        public virtual void Draw(RenderWindow renderWindow)
        {
            if (_isLoaded)
            {
                renderWindow.Draw(_sprite);
            }
        }

        public virtual void Update(float elapsedTime)
        {
        }

        public  virtual float GetHeight()
        {
            return _texture.Size.Y;
        }

        public virtual float GetWidth()
        {
            return _texture.Size.X;
        }

        public virtual FloatRect GetBoundingRect()
        {
            //Vector2f size = new Vector2f(_texture.Size.X, _texture.Size.Y);
            //Vector2f position = new Vector2f(_sprite.Position.X, _sprite.Position.X);

            //return new FloatRect(position.X - size.X/2, position.Y - size.Y/2, position.X + size.X/2, position.Y + size.Y/2);
            return _sprite.GetGlobalBounds();

        }

        public virtual Vector2f GetPosition()
        {
            if (_isLoaded)
            {
                return _sprite.Position;
            }

            return new Vector2f();
        }

        public virtual bool IsLoaded()
        {
            return _isLoaded;
        }

        public virtual void SetPosition(float x, float y)
        {
            if (_isLoaded)
            {
                _sprite.Position = new SFML.System.Vector2f(x, y);
            }
        }

        protected Sprite GetSprite()
        {
            return _sprite;
        }


    }
}
