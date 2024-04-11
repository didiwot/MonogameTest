using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST1.MenuSharp.src
{
    interface IMenu
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public void Update(GameTime gameTime, StateManager state);

    }
}
