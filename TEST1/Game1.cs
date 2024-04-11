using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Content;
using TiledSharp;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using TEST1.MenuSharp.src;

namespace TEST1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private TmxMap map;
        private TileMapManager mapManager;
        private List<Rectangle> collisionObjects;
        private Matrix matrix;

        private Menu startMenu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Services.AddService(typeof(StateManager), new StateManager());

            startMenu = new Menu(this, Content);

            player = new Player();
            _graphics.PreferredBackBufferWidth = 256 * 2;//Making the window size twice our tilemap size
            _graphics.PreferredBackBufferHeight = 256 * 2;
            _graphics.ApplyChanges();
            var Width = _graphics.PreferredBackBufferWidth;
            var Height = _graphics.PreferredBackBufferHeight;
            var WindowSize = new Vector2(Width, Height);
            var mapSize = new Vector2(256, 256);//Our tile map size
            matrix = Matrix.CreateScale(new Vector3(WindowSize / mapSize, 1));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            map = new TmxMap("Content/map.tmx");
            var tileset = Content.Load<Texture2D>("Tiny Adventure Pack/" + map.Tilesets[0].Name.ToString());
            var tileWidth = map.Tilesets[0].TileWidth;
            var tileHeight = map.Tilesets[0].TileHeight;
            var TileSetTilesWide = tileset.Width / tileWidth;
            mapManager = new TileMapManager(_spriteBatch, map, tileset, TileSetTilesWide, tileWidth, tileHeight);
            collisionObjects = new List<Rectangle>();
            foreach (var o in map.ObjectGroups["Collisions"].Objects)
            {
                collisionObjects.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }

            SpriteSheet[] sheets = { Content.Load<SpriteSheet>("Tiny Adventure Pack/Character/char_two/Idle/playerSheetIdle.sf",new JsonContentLoader()),
                                    Content.Load<SpriteSheet>("Tiny Adventure Pack/Character/char_two/Walk/playerSheetWalk.sf",new JsonContentLoader())};
            player.Load(sheets);

        }

        protected override void Update(GameTime gameTime)
        {
            var service = Services.GetService(typeof(StateManager)) as StateManager;

            //service.ChangeState(State.Play);

            switch (service.GetCurrentState()) {
                case (State.Menu):
                    
                    startMenu.Update(gameTime, service);


                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();

                    break;
                case (State.Play):

                    var initpos = player.pos;
                    player.Update(gameTime);
                    foreach (var rect in collisionObjects)
                    {
                        if (rect.Intersects(player.playerBounds))
                        {
                            player.pos = initpos;
                            player.isIdle = true;
                        }
                    }
                    break;
                case (State.Stop):

                    break;
            }
                

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var service = Services.GetService(typeof(StateManager)) as StateManager;

            //service.ChangeState(State.Play);

            switch (service.GetCurrentState())
            {
                case (State.Menu):
                    Menu startMenu = new Menu(this, Content);
                    startMenu.Draw(gameTime, _spriteBatch);

                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();

                    break;
                case (State.Play):

                    mapManager.Draw(matrix);
                    player.Draw(_spriteBatch, matrix);
                    break;
                case (State.Stop):

                    break;
            }


            base.Draw(gameTime);
        }
    }
}
