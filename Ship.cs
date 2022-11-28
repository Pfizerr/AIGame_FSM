using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class Ship : Entity
    {
        protected float health;
        protected float maxHealth;
        protected float speed;

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

        public Ship(Vector2 position, Point size, Texture2D texture, float maxSpeed) : base(position, size, maxSpeed, texture)
        {
            this.texture = texture;
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(texture, boundingBox, null, Color.Orange, 0f, boundingBox.Size.ToVector2() * 0.5f, SpriteEffects.None, 0f);
        //    spriteBatch.Draw(texture, Position, null, Color.White, 0f, size.ToVector2() * 0.5f, 1f, SpriteEffects.None, 0f);
        //}
    }
}