using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST1.ButtunSharp.src
{
    interface IButton
    {
        public event EventHandler Click;

        public void Update(GameTime gameTime, StateManager stateManager); //Зачем нам тут вообще изменять состояние сделаем это выше???? ps 72 строчка
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
