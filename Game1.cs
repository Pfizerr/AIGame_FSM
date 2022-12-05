using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<AIShip> aiShips;
        private Point clientBounds;
        private Cursor cursor;

        public static Random random = new Random();
        public static SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("trebuchetms");

            clientBounds = new Point(1000, 700);
            graphics.PreferredBackBufferWidth = clientBounds.X;
            graphics.PreferredBackBufferHeight = clientBounds.Y;
            graphics.ApplyChanges();

            aiShips = new List<AIShip>();
            cursor = new Cursor(new Point(4, 4), CreateFilledRectangle(4, 4, Color.White));
            aiShips.Add(new AIShip(cursor, new Vector2(clientBounds.X / 2, clientBounds.Y / 2), new Point(32, 32), CreateFilledRectangle(32, 32, Color.Blue), 60));
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            
            for (int i = 0; i < aiShips.Count; i++)
            {
                if (aiShips[i].IsAlive)
                {
                    aiShips[i].Update(gameTime);
                }
                else
                {
                    // handle dead aiship.
                    aiShips.RemoveAt(i);
                }
            }

            cursor.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            
            foreach (AIShip aiShip in aiShips)
            {
                aiShip.Draw(spriteBatch);
            }

            cursor.Draw(spriteBatch);

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

        public static Entity GetNearestEntity(Vector2 location)
        {
            return null;
        }
            
    }
}
