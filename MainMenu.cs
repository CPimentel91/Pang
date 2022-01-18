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
    /*
    class MainMenu
    {
        
        static Texture texture = new Texture(@"D:\PICTURES\MainMenu.png");
        static Texture texturePlayGame = new Texture(@"D:\PICTURES\PlayGame.png");
        static Texture textureExitGame = new Texture(@"D:\PICTURES\ExitGame.png");
        static Sprite sprite = new Sprite(texture);
        static Sprite spritePlayGame = new Sprite(texturePlayGame);
        static Sprite spriteExitGame = new Sprite(textureExitGame);
        //static SFML.System.Vector2f playGameArea = spritePlayGame.Position;
        //static SFML.System.Vector2f exitGameArea = spriteExitGame.Position;
        static MenuResult result = MenuResult.Nothing;



        private static List<MenuItem> _menuItems;
        public enum MenuResult
        {
            Nothing,
            Exit,
            Play,
            ass
        };

        struct MenuItem
        {
            public IntRect rect;
            public MenuResult action;
        }

        public MenuResult Show(RenderWindow renderWindow)
        {

            renderWindow.MouseButtonPressed += OnMouseLeftClickPlay;
            renderWindow.MouseButtonPressed += OnMouseLeftClickExit;
            renderWindow.Draw(sprite);
            spritePlayGame.Position = new SFML.System.Vector2f(0, 145);
            spriteExitGame.Position = new SFML.System.Vector2f(0, 383);
            renderWindow.Draw(spritePlayGame);
            renderWindow.Draw(spriteExitGame);
            renderWindow.Display();

            return GetMenuResponse(renderWindow);
            
        }

        private MenuResult GetMenuResponse(RenderWindow renderWindow)
        {
            //renderWindow.Closed
            while (42 != 43)
            {
                renderWindow.DispatchEvents();
                if(result != MenuResult.Nothing)
                {
                    return result;
                }
            }
            
            
        }
        
        private MenuResult HandleClick(int x, int y)
        {

            foreach (var item in _menuItems)
            {
                IntRect menuItemRect = item.rect;
                if(menuItemRect.Height > y && menuItemRect.Top < y && menuItemRect.Left < x && menuItemRect.Width > x)
                {
                    return item.action;
                }
            }


            return MenuResult.Nothing;
        }
        
        static void OnMouseLeftClickPlay(object sender, EventArgs e)
        {
            if ((Vector2f)Mouse.GetPosition() == spritePlayGame.Position && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                result = MenuResult.Play;
            }

            result = MenuResult.Nothing;
        }

        static void OnMouseLeftClickExit(object sender, EventArgs e)
        {

            RenderWindow window = (RenderWindow)sender;
            window.Close();

            if (((Vector2f)Mouse.GetPosition()) == spriteExitGame.Position && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                result = MenuResult.Exit;
            }

            result = MenuResult.Nothing;
        }
    
    }
    */
}

