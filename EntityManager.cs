using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace AIGame
{
	public static class EntityManager
    {
        private static List<Entity> entities = new List<Entity>();

        public static void AddAIShip(AIShip entity) => entities.Add(entity);
        public static void AddBoid(Boid entity) => entities.Add(entity);
        public static void AddShip(Ship entity) => entities.Add(entity);

        public static void AddEntity(Cursor entity) => entities.Add(entity);

        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < entities.Count; i++)
            {

                if (entities[i].IsAlive == false)
                {
                    entities.RemoveAt(i);
                }
                else
                {
                    entities[i].Update(gameTime);
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}