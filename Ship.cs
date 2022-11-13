using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class Ship : Entity
    {

        protected Texture2D texture;
        protected Rectangle boundingBox;
        protected Vector2 position;
        protected Point size;
        protected float speed;
        
        public virtual float Health
        {
            get;
            protected set;
        }

        public virtual Vector2 Position
        {
            get
            {
                return position;
            }
            protected set
            {
                position = value;
            }
        }

        public Ship(Vector2 position, Point size, Texture2D texture, float speed) : base()
        {
            this.position = position;
            this.size = size;
            this.texture = texture;

            boundingBox = new Rectangle(position.ToPoint(), size); 
        }

        public override void Update(GameTime gameTime)
        {
            boundingBox.Location = position.ToPoint() - new Point(size.X / 2, size.Y / 2);
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, new Vector2(-size.X / 2, -size.Y / 2), 1f, SpriteEffects.None, 0);
        }
    }
}