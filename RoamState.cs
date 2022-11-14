using Microsoft.Xna.Framework;
using System;

namespace AIGame
{
	public class RoamState : ShipState
    {
        private Entity target;


        public RoamState(AIShip parent, Entity target) : base(ShipStateType.STATE_ROAM, parent)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {

            // IDLE ..

            float dt = (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f);


            if (parent.Velocity.Length() < parent.Speed * 0.1f)
            {
                parent.Velocity = Vector2.Zero;
            }
            else
            {
                parent.Velocity -= parent.Velocity * 0.5f * dt;
            }

            base.Update(gameTime);
        }

        public override ShipStateType CheckTransitions()
        {
            if (parent.DistanceToTarget < parent.MinDetectionDistance)
            {
                if (parent.Health < parent.MinEngagementHealth)
                {
                    return ShipStateType.STATE_FLEE; // A - C, (Roam -> Flee)
                }
                else
                {
                    return ShipStateType.STATE_CHASE; // A - B, (Roam -> Chase)
                }
            }

            return base.CheckTransitions();
        }

    }
}