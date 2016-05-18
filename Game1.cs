using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Square_Jumper
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player;
        public Rectangle playerPlacement;

        Texture2D ground;
        Vector2 groundPlacement;

        public Vector2 spritePosition;
        
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;  
            graphics.PreferredBackBufferHeight = 640;   
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            playerPlacement = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, playerPlacement.Width, playerPlacement.Height); ;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = this.Content.Load<Texture2D>("playersheet");
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
                playerPlacement.Y -= 10;
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
                playerPlacement.Y += 10;
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
                playerPlacement.X += 10;
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                playerPlacement.X -= 10;
            if (playerPlacement.X > 640 - 32)
                playerPlacement.X = 640 - 32;
            if (playerPlacement.X < 0)
                playerPlacement.X = 0;
            if (playerPlacement.Y < 0)
                playerPlacement.Y = 0;
            if (playerPlacement.Y > 640 - 32)
                playerPlacement.Y = 640 - 32;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(player, destinationRectangle: new Rectangle((int)playerPlacement.X, (int)playerPlacement.Y, 32, 32));
            spriteBatch.End();
           
            base.Draw(gameTime);
        }
    }
}
