using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace topic_2_monogame_lists_etc
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _ballImage;
        Texture2D _backgroundImage;
        SpriteFont _font;

        List<Texture2D> _balls = new List<Texture2D>();

        int _score = 0;
        float _timer = 0f;
        MouseState _oldMouse;
        Random _rng = new Random();
        bool _onTitleScreen = true;
        bool _gameOver = false;
        const float GAME_LENGTH = 20f;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ballImage = Content.Load<Texture2D>("");
            _backgroundImage = Content.Load<Texture2D>("");
            _font = Content.Load<SpriteFont>("");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouse = Mouse.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_onTitleScreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    _onTitleScreen = false;
            }
            else if(_gameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    _balls.Clear();
                    _score = 0;
                    _timer = 0f;
                    _gameOver = false;
                }
            }
            else
            {
                _timer += dt;

                if(_timer >= GAME_LENGTH)
                    _gameOver = true;
                if (mouse.LeftButton == ButtonState.Pressed && _oldMouse.LeftButton == ButtonState.Released)
                {





                }
            }
                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
