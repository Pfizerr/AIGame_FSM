using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
    public interface ISteerable
    {
        void SteeringThrustAccumulate(Vector2 totalSteeringForce);
    }

	public class Boid : Entity, ISteerable
    {
        private SteeringControl control;

        public Boid(Vector2 position, Point size, /*Vector2 direction,*/ float maxSpeed, Texture2D texture) : base(position, size, maxSpeed, texture)
        {
            //control = new SteeringControl(this);   
        }

        public override void Update(GameTime gameTime)
        {
            //control.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //control.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public void SteeringThrustAccumulate(Vector2 totalSteeringForce)
        {

        }

    }
}