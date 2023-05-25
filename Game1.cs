using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mongam_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D circleTex;
        Texture2D squareTex;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.PreferredBackBufferWidth = 640;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Window.Title = "Checkerboard";

            Window.AllowUserResizing = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            circleTex = Content.Load<Texture2D>("circle");
            squareTex = Content.Load<Texture2D>("square");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            //squares
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _spriteBatch.Draw(squareTex, new Rectangle((_graphics.PreferredBackBufferWidth / 4) * j, (_graphics.PreferredBackBufferHeight / 4) * i, 80, 80), Color.Black);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _spriteBatch.Draw(squareTex, new Rectangle(((_graphics.PreferredBackBufferWidth / 4) * j) + 80, ((_graphics.PreferredBackBufferHeight / 4) * i) + 80, 80, 80), Color.Black);
                }
            }

            //circles left
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _spriteBatch.Draw(circleTex, new Rectangle((_graphics.PreferredBackBufferWidth / 4) * j, (_graphics.PreferredBackBufferHeight / 4) * i, 80, 80), Color.Blue);
                }
                for (int j = 0; j < 4; j++)
                {
                    _spriteBatch.Draw(circleTex, new Rectangle(((_graphics.PreferredBackBufferWidth / 4) * j), ((_graphics.PreferredBackBufferHeight / 4) * i) + 400, 80, 80), Color.Red);
                }
            }
            //circles right
            for (int j = 0; j < 4; j++)
            {
                _spriteBatch.Draw(circleTex, new Rectangle(((_graphics.PreferredBackBufferWidth / 4) * j) + 80, ((_graphics.PreferredBackBufferHeight / 4)) - 80, 80, 80), Color.Blue);
            }
            for (int j = 0; j < 4; j++)
            {
                _spriteBatch.Draw(circleTex, new Rectangle(((_graphics.PreferredBackBufferWidth / 4) * j) + 80, ((_graphics.PreferredBackBufferHeight / 4)) + 320, 80, 80), Color.Red);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
