using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST1.ButtunSharp.src;

namespace TEST1.MenuSharp.src
{

    internal class Menu : IMenu
    {
        private List<RenderButton> _components;

        private Game1 _game;
        private StateManager _state;

        public Menu(Game1 game, ContentManager _content)
        {
            _game = game; // хз насколько это правильно 


            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new RenderButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 50),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new RenderButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Game",
            };
            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new RenderButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit Game",
            };
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<RenderButton>()
        {
            newGameButton,
            loadGameButton,
            quitGameButton,
        };
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }



        public void Update(GameTime gameTime, StateManager state)
        {
            _state = state;
            foreach (var component in _components)
                component.Update(gameTime, _state);
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _state.ChangeState(State.Play);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {

            _game.Exit();
        }
    }
}
