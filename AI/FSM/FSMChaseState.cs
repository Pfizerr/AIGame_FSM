using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;

namespace AIGame
{
	public class FSMChaseState : FSMState
    {
        private Entity target;

        public FSMChaseState(AIShip parent, Entity target) : base(ShipStateType.FSM_STATE_CHASE, parent)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 dpos = Vector2.Normalize(target.Position - parent.Position);
            parent.Velocity = dpos * parent.MaxSpeed;

            base.Update(gameTime);
        }

        public override ShipStateType CheckTransitions()
        {

            if (parent.DistanceToTarget > parent.MinDetectionDistance)
            {
                return ShipStateType.FSM_STATE_ROAM; // B - A, (Chase -> Roam)
            }

            else if (parent.Health < parent.MinEngagementHealth)
            {
                return ShipStateType.FSM_STATE_FLEE; // B - C, (Chase -> Flee)
            }

            else if (parent.DistanceToTarget < parent.MinEngagementDistance)
            {
                return ShipStateType.FSM_STATE_ENGAGE; // B - D, (Chase -> Engage)
            }

            return base.CheckTransitions();
        }
    }
}