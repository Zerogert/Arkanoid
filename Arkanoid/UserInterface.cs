using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    //class describing a graphical user interface. Depending on the state, it shows different interfaces(main menu, pause menu, game interface).
    public class UserInterface
    {
        private MainMenu mainMenu;//MainMenu
        private InterfaceGame interfaceGame;
        private MenuPause menuPause;
        public EGameState gameState = EGameState.MainMenu;//game states
        public Game1 game;//main class

        public UserInterface()
        {

        }

        public void Initialize(Game1 game)
        {
            this.game = game;
            mainMenu = new MainMenu(this, game, new Point((game.GraphicsDevice.DisplayMode.Width/2)-game.Width/4, (game.Y0+game.Height/2)- game.Height / 4), game.Width/2, game.Height/3);
            menuPause = new MenuPause(this, game, new Point((game.GraphicsDevice.DisplayMode.Width / 2)-(game.Width / 4)/2, game.Height/2-(game.Height / 5)/2), game.Width/4, game.Height/5);
            interfaceGame = new InterfaceGame(this, game, new Point((game.X0 + game.Width+32), 32), 32*8, game.Height);
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(KeyboardState kstate, GameTime gameTime)
        {
            if (kstate.IsKeyDown(Keys.Escape))
            {
                if (gameState == EGameState.Game)
                {
                    gameState = EGameState.GamePause;
                    game.gameProcess.Pause();
                }
            }
            switch (gameState)
            {
                case EGameState.MainMenu:
                    mainMenu.Update(kstate, gameTime);
                    break;
                case EGameState.Game:
                    game.gameProcess.Run();
                    interfaceGame.Update(kstate, gameTime);
                    break;
                case EGameState.GamePause:
                    menuPause.Update(kstate, gameTime);
                    break;
                case EGameState.Exit:
                    game.Exit();
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case EGameState.MainMenu:
                    mainMenu.Draw(spriteBatch);
                    break;
                case EGameState.Game:
                    interfaceGame.Draw(spriteBatch);
                    break;
                case EGameState.GamePause:
                    menuPause.Draw(spriteBatch);
                    interfaceGame.Draw(spriteBatch);
                    break;
                case EGameState.Exit:
                    break;
                default:
                    break;
            }
        }
    }
}
