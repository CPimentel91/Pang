using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PangTutorial
{
    class GameObjectManager
    {
        public GameObjectManager()
        {

        }

        public void Add(string name, VisibleGameObject gameObject)
        {
            gameObjects.Add(name, gameObject);
        }

        public void Remove(string name)
        {
            gameObjects.Remove(name);
        }

        public int GetObjectCount()
        {
            return gameObjects.Count;
        }

        public VisibleGameObject Get(string name)
        {

            return gameObjects[name];
            
        }

        public void DrawAll(RenderWindow renderWindow)
        {
            foreach (var objects in gameObjects.Values)
            {
                objects.Draw(renderWindow);
            }
        }

        public void UpdateAll()
        {

            foreach (var objects in gameObjects.Values)
            {
                objects.Update(Game.clock.Restart().AsSeconds());
            }
        }

        private Dictionary<string, VisibleGameObject> gameObjects = new Dictionary<string, VisibleGameObject>();

    }
}
