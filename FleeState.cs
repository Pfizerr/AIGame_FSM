using Microsoft.Xna.Framework;

namespace AIGame
{
	public class FleeState : ShipState
    {
        private Entity target;

        public FleeState(AIShip parent, Entity target) : base(ShipStateType.STATE_FLEE, parent)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 distNormal = Vector2.Normalize(target.Position - parent.Position);
            parent.Velocity = distNormal * parent.Speed * -1;

            base.Update(gameTime);
        }

        public override ShipStateType CheckTransitions()
        {
            if (target.IsActive == false || parent.DistanceToTarget > parent.MinDetectionDistance)
            {
                return ShipStateType.STATE_ROAM;
            }

            if (parent.Health > parent.MinEngagementHealth)
            {
                return ShipStateType.STATE_CHASE;
            }


            return base.CheckTransitions();
        }
    }
}