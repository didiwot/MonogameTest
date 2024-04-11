using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST1.ButtunSharp.src
{

    internal abstract class PatternButton
    {

        private protected MouseState _currentMouse;
        private protected SpriteFont _font;
        private protected bool _isHovering;
        private protected MouseState _previousMouse;
        private protected Texture2D _texture;

        public bool Clicked { get; set; }
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public string Text { get; set; }
        public PatternButton(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.Black;
        }

    }

    

}
