using Microsoft.Xna.Framework;

namespace AIGame
{
	public class SteerApproach : SteeringBehaviour
    {
        public SteerApproach(SteeringControl parent, string name) : base(parent, name)
        {

        }

        public override bool Update(GameTime gameTime, Vector2 totalForce)
        {
            bool adjustment = false;
            bool found = FindTarget();

            if (found)
            {
                Vector2 steeringForce = Vector2.Zero;
                //SteerTowards(currentTarget, steeringForce);
                totalForce += steeringForce;
                adjustment = true;
            }

            return adjustment;
        }

        public bool FindTarget()
        {
            bool rval = false;

            return rval;
        }
    }
}