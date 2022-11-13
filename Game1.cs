using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Ship[] ships;
        private Point clientBounds;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            clientBounds = new Point(1920, 1080);
            graphics.PreferredBackBufferWidth = clientBounds.X;
            graphics.PreferredBackBufferHeight = clientBounds.Y;
            graphics.ApplyChanges();


            ships = new Ship[2];
            ships[0] = new Ship(new Vector2(180, 500), new Point(32, 32), CreateFilledRectangle(32, 32, Color.Blue), 20);
            ships[1] = new AIShip(ships[0], new Vector2(1700, 500), new Point(32, 32), CreateFilledRectangle(32, 32, Color.Red), 17);
            
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();


            foreach(Ship ship in ships)
            {
                ship.Update(gameTime);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            foreach(Ship ship in ships)
            {
                ship.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


        private Texture2D CreateFilledRectangle(int width, int height, Color color)
        {
            Color[] data = new Color[width * height];
            Texture2D rectTexture = new Texture2D(GraphicsDevice, width, height);

            for (int i = 0; i < width * height; i++)
            {
                data[i] = color;
            }

            rectTexture.SetData(data);
            return rectTexture;
        }
    }
}
