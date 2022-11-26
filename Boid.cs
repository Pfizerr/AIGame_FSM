using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class Boid : Entity
    {
        private float speed;
        private Vector2 direction;

        public Boid(Vector2 position, Vector2 direction, float speed) : base(position)
        {
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}