using Microsoft.Xna.Framework;
using System;

namespace AIGame
{
	public class FSMRoamState : FSMState
    {
        private Entity target;

        public FSMRoamState(AIShip parent, Entity target) : base(ShipStateType.FSM_STATE_ROAM, parent)
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
                    return ShipStateType.FSM_STATE_FLEE; // A - C, (Roam -> Flee)
                }
                else
                {
                    return ShipStateType.FSM_STATE_CHASE; // A - B, (Roam -> Chase)
                }
            }

            return base.CheckTransitions();
        }

    }
}