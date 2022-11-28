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
        private Point clientBounds;

        public static SpriteFont font;
        public static Random random = new Random();

        private List<AIShip> aiShips;
        private List<Boid> boids;
        private Cursor cursor;


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
            boids = new List<Boid>();

            cursor = new Cursor(new Point(4, 4), CreateFilledRectangle(4, 4, Color.White));
            aiShips.Add(new AIShip(cursor, new Vector2(clientBounds.X / 2, clientBounds.Y / 2), new Point(32, 32), CreateFilledRectangle(32, 32, Color.Blue), 60));


            for (int i = 0; i < 20; i++)
            {
                Vector2 randPos = new Vector2(random.Next(0, clientBounds.X), random.Next(0, clientBounds.Y));
                boids.Add(new Boid(randPos, new Point(2, 2), 50.0f, CreateFilledRectangle(2, 2, Color.White)));
            }
            
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
                }
            }

            for (int i = 0; i < boids.Count; i++)
            {
                if (boids[i].IsAlive)
                {
                    boids[i].Update(gameTime);
                }
                else
                {
                    // handle dead boid.
                }
            }

            cursor.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            foreach (Boid boid in boids)
                boid.Draw(spriteBatch);
            
            foreach (AIShip aiShip in aiShips)
                aiShip.Draw(spriteBatch);

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
    }

    public static Entity GetNearestEntity(Vector2 location)
    {

    }
}
