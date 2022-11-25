using Microsoft.Xna.Framework;

namespace AIGame
{
	public class FSMFleeState : FSMState
    {
        private Entity target;

        public FSMFleeState(AIShip parent, Entity target) : base(ShipStateType.FSM_STATE_FLEE, parent)
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
                return ShipStateType.FSM_STATE_ROAM;
            }

            else if (parent.Health > parent.MinEngagementHealth)
            {
                return ShipStateType.FSM_STATE_CHASE;
            }


            return base.CheckTransitions();
        }
    }
}