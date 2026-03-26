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
        List<Vector2> _positions = new List<Vector2>();

        int _score = 0;
        MouseState _oldMouse;
       


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
            _ballImage = Content.Load<Texture2D>("ballimage");
            _backgroundImage = Content.Load<Texture2D>("backgroundball");
            _font = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouse = Mouse.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(mouse.LeftButton == ButtonState.Pressed && _oldMouse.LeftButton == ButtonState.Released)
            {
                _balls.Add(_ballImage);
                _positions.Add(new Vector2(mouse.X, mouse.Y));
                _score++;
            }
            if (mouse.RightButton == ButtonState.Pressed && _oldMouse.RightButton == ButtonState.Released)
            {
                if(_balls.Count > 0)
                {
                    _balls.RemoveAt(_balls.Count - 1);
                    _positions.RemoveAt(_positions.Count - 1); 
                }
                
            }
            _oldMouse = mouse;
            base.Update(gameTime);
                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_backgroundImage, Vector2.Zero, Color.White);
            for(int i = 0; i < _balls.Count; i++)
            {
                if (_positions[i].Y < GraphicsDevice.Viewport.Height - 30)
                    _positions[i] = new Vector2(_positions[i].X, _positions[i].Y + 2);


                _spriteBatch.Draw(_balls[i], _positions[i], null, Color.White, 0f, new Vector2(_ballImage.Width / 2, _ballImage.Height / 2), 0.3f, SpriteEffects.None, 0f);
            }

            _spriteBatch.DrawString(_font, "Score: " + _score, new Vector2(10,10), Color.White);
            _spriteBatch.DrawString(_font, "Balls: " + _balls.Count, new Vector2(10, 40), Color.White);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
