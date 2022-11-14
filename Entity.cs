using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public abstract class Entity 
    {
        protected Vector2 position;
        protected bool isActive;

        public Vector2 Position
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

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            protected set
            {
                isActive = value;
            }
        }

        public Entity(Vector2 position)
        {
            this.position = position;
            isActive = true;
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}