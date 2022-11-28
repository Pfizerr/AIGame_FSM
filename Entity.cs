using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public abstract class Entity 
    {
        protected bool isAlive;
        protected float maxSpeed;
        protected Vector2 position;
        protected Vector2 velocity;
        protected Texture2D texture;
        protected Rectangle boundingBox;
        protected Point size;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool IsAlive
        {
            get { return isAlive; } 
            set { isAlive = value; }
        }

        public virtual float MaxSpeed
        {
            get { return maxSpeed; }
            protected set { maxSpeed = value; }
        }

        public virtual Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Entity(Vector2 position, Point size, float maxSpeed, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
            this.size = size;
            this.maxSpeed = maxSpeed;

            boundingBox = new Rectangle(position.ToPoint(), size);
            velocity = Vector2.Zero;
            isAlive = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            boundingBox.Location = Position.ToPoint() - new Point(size.X / 2, size.Y / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            //spriteBatch.Draw(texture, boundingBox, null, Color.Orange, 0f, boundingBox.Size.ToVector2() * 0.5f, SpriteEffects.None, 0f);
        }
    }
}