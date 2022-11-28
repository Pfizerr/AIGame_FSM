using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class SteeringControl
    {
        private SteeringBehaviourManager manager;
        int getPowerupIndex;
        public Boid Parent { get; set; }
        public Entity nearestEntity { get; set; }
        public float safetyRadius { get; set; }

        public SteeringControl(Boid boid = null)
        {
            Parent = boid;
            getPowerupIndex = -1;

            manager.AddBehaviour(new SteerApproach(this, "STEERING_BEHAVIOUR_APPROACH"));
            manager.AddBehaviour(new SteerPursuit(this, "STEERING_BEHAVIOUR_PURSUIT"));

            manager.Reset();

            //initialize all the weights and probability values for the behaviours
            manager.SetupBehaviour(0, 3.5f, 1.0f);
            manager.SetupBehaviour(1, 4.0f, 1.0f);
        }

        public void Update(GameTime gameTime)
        {
            if (Parent.IsAlive == false
                || Parent == null)
            {
                manager.Reset();
                return;
            }

            UpdatePerceptions(gameTime);
            manager.Update(gameTime);
            Vector2 totalSteeringForce = manager.GetFinalSteeringVector();

            // apply forces
            Parent.SteeringThrustAccumulate(totalSteeringForce);


        }

        public void UpdatePerceptions(GameTime gameTime)
        {

        }

        public void Init()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Reset()
        {

        }

        
    }
}