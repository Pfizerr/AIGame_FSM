using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public abstract class SteeringBehaviour
    {
        protected SteeringControl parent;
        protected float weight;
        protected string name;
        protected float lastForceApplied;

        public bool Disable { get; set; }
        public float Probability { get; set; }
        public float Weight { get; set; }


        public SteeringBehaviour(SteeringControl parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }

        public virtual void SteerTowards(Vector2 target, Vector2 result) // ?out?
        {
            Vector2 desired = target - parent.Parent.Position;
            float targetDistance = desired.Length();
            
            if (targetDistance > 0)
            {
                desired = Vector2.Normalize(desired) * parent.Parent.MaxSpeed;
                result = desired - parent.Parent.Velocity;
            }
            else
            {
                result = Vector2.Zero;
            }
        }

        public virtual void SteerAway(Vector2 target, Vector2 result) // ?out?
        {
            Vector2 desired = parent.Parent.Position - target;
            float targetDistance = desired.Length();

            if (targetDistance > 0)
            {
                desired = Vector2.Normalize(desired) * parent.Parent.MaxSpeed;
                result = desired - parent.Parent.Velocity;
            }
            else
            {
                result = Vector2.Zero;
            }

        }

        public virtual bool Update(GameTime gameTime, Vector2 totalForce) //?out?
        {
            return false;
        }

        //public abstract void Draw(SpriteBatch spriteBatch);
        //public abstract void Reset();
    }
}