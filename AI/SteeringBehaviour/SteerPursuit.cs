using Microsoft.Xna.Framework;

namespace AIGame
{
	public class SteerPursuit : SteeringBehaviour
    {
        public SteerPursuit(SteeringControl parent, string name) : base (parent, name)
        {

        }

        public override bool Update(GameTime gameTime, Vector2 totalForce)
        {
            bool adjustment = false;
            bool found = FindTarget();

            return false;
        }

        public bool FindTarget()
        {
            bool rval = false;

            //if the guy you're pursuinmg is essentially in your path, then just approach, otherweise we'll try and head him off using prediction


            return rval;
        }
    }
}