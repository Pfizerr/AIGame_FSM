using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace AIGame
{
	public class SteeringBehaviourManager
    {
        private List<SteeringBehaviour> behaviours;
        private List<SteeringBehaviour> active;
        private List<float> activeForce;
        private int behaviourCount;
        private SteeringControl parent;
        private Vector2 totalSteeringForce;
        private float maxSteeringForce;


        public SteeringBehaviourManager(SteeringControl parent)
        {
            this.parent = parent;
        }

        public void Update(GameTime gameTime)
        {
            if (behaviours.Count == 0)
            {
                return; //don't do anything if there are no states.
            }

            active.Clear();         // clear out debug logs..
            activeForce.Clear();    // ..
            totalSteeringForce = Vector2.Zero; // reset the steering vector
            
            // update all the behaviours
            bool needToClamp = false;

            for (int i = 0; i < behaviours.Count; i++)
            {
                Vector2 steeringForce = Vector2.Zero;
                bool hasDoneSomething = behaviours[i].Update(gameTime, steeringForce);

                if (hasDoneSomething)
                {
                    // keep track of behaviours that did something this tick

                    active.Add(behaviours[i]);
                    activeForce.Add(steeringForce.Length());

                    // now we want to to combine the behaviours into the total
                    // steering force using whatever method we decide upon

                    bool willKeepGoing = false;

                    // "Simple Weighted Combination"
                    // willKeepGoing = CombineForceWeighted(steeringForce, behaviours[i].Weight);
                    // needToClamp = true; //must "normalize" results

                    // "Prioritized Dither"
                    // keepGoing = CombineForcePriorityDithered(steeringForce, behaviours[i].Weight);
                    // needToClamp = true;

                    // "Prioritized Sum"
                    willKeepGoing = CombineForcePrioritySum(steeringForce, behaviours[i].Weight);

                    if (!willKeepGoing)
                    {
                        break; // if we are dont checking behaviours for whatever reason, exit out.
                    }
                }

                if (needToClamp)
                {
                    // clamp vector length ... (totalSteeringForce, 0.0f, maxSteeringForce)
                }
            }
        }

        public void AddBehaviour(SteeringBehaviour behaviour)
        {
            behaviours.Add(behaviour);
        }

        public void DisableBehaviour(int index)
        {
            behaviours[index].Disable = true;
        }

        public void SetupBehaviour(int index, float weight, float probability, bool disable = false)
        {
            behaviours[index].Weight = weight;
            behaviours[index].Probability = probability;
            behaviours[index].Disable = disable;
        }

        public Vector2 GetFinalSteeringVector()
        {
            return Vector2.Zero;
        }

        public bool CombineForceWeighed(Vector2 steeringForce, float weight)
        {
            totalSteeringForce += steeringForce * weight;
            return false;
        }

        public bool CombineForcePrioritySum(Vector2 steeringForce, float weight)
        {
            bool rval = false;
            float totalForce = totalSteeringForce.Length();
            float forceLeft = maxSteeringForce - totalForce;
            if (forceLeft > 0.0f)
            {
                float newForce = steeringForce.Length();
                if (newForce < forceLeft)
                {
                    totalSteeringForce += steeringForce;
                }
                else
                {
                    totalSteeringForce += Vector2.Normalize(steeringForce) * forceLeft;
                }

                if (forceLeft - newForce > 0.0f)
                {
                    rval = true; // if there's anything left over, say so
                }
                    
            }
            return rval;
        }

        public bool CombineForcePriorityDithered(Vector2 steeringForce, float weight, float randChance)
        {
            bool rval = false;
            if (Game1.random.Next() < randChance)
            {
                if (steeringForce.Length() > 0)
                {
                    totalSteeringForce = steeringForce;
                    rval = true;
                }
            }

            return rval;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Reset()
        {

        }
    }
}