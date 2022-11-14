using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class Ship : Entity
    {
        protected Texture2D texture;
        protected Rectangle boundingBox;
        protected Point size;

        protected float health;
        protected float maxHealth;
        protected float speed;
        protected Vector2 velocity;

        //protected ShipStateMachine stateMachine;


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

        public virtual float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
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
            spriteBatch.Draw(texture, boundingBox, null, Color.Orange, 0f, boundingBox.Size.ToVector2() * 0.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, size.ToVector2() * 0.5f, 1f, SpriteEffects.None, 0f);
        }
    }
}