using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class Ship : Entity
    {
        protected Rectangle boundingBox;
        protected Texture2D texture;
        protected Vector2 velocity;
        protected float maxHealth;
        protected float health;
        protected float speed;
        protected Point size;
        

        public virtual float Speed
        {
            get
            {
                return speed;
            }
            protected set
            {
                speed = value;
            }
        }

        public virtual float Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        
        public virtual float MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }

        public virtual Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }



        public Ship(Vector2 position, Point size, Texture2D texture, float speed) : base(position)
        {
            this.size = size;
            this.texture = texture;
            this.speed = speed;
            this.position = position;
            isActive = false;
            velocity = Vector2.Zero;
            boundingBox = new Rectangle(position.ToPoint(), size); 
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                Position += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            }

            boundingBox.Location = Position.ToPoint() - new Point(size.X / 2, size.Y / 2);
            base.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, size.ToVector2() * 0.5f, 1f, SpriteEffects.None, 0f);
        }
    }
}