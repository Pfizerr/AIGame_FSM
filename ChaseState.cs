using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;

namespace AIGame
{
	public class ChaseState : ShipState
    {
        private Entity target;

        public ChaseState(AIShip parent, Entity target) : base(ShipStateType.STATE_CHASE, parent)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 dpos = Vector2.Normalize(target.Position - parent.Position);
            parent.Velocity = dpos * parent.Speed;

            base.Update(gameTime);
        }

        public override ShipStateType CheckTransitions()
        {

            if (parent.DistanceToTarget > parent.MinDetectionDistance)
            {
                return ShipStateType.STATE_ROAM; // B - A, (Chase -> Roam)
            }
            else
            {
                if (parent.Health < parent.MinEngagementHealth)
                {
                    return ShipStateType.STATE_FLEE; // B - C, (Chase -> Flee)
                }
                if (parent.DistanceToTarget < parent.MinEngagementDistance)
                {
                    return ShipStateType.STATE_ENGAGE; // B - D, (Chase -> Engage)
                }
            }

            return base.CheckTransitions();
        }
    }
}