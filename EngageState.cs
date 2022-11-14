using Microsoft.Xna.Framework;

namespace AIGame
{
	public class EngageState : ShipState
    {
        private Entity target;

        public EngageState(AIShip parent, Entity target) : base(ShipStateType.STATE_ENGAGE, parent)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override ShipStateType CheckTransitions()
        {
            if (target.IsActive == false)
            {
                return ShipStateType.STATE_ROAM; // D - A (Engage -> Roam)
            }

            if (parent.Health < parent.MinEngagementHealth)
            {
                return ShipStateType.STATE_FLEE; // D - C (Engage -> Flee)
            }

            if (parent.DistanceToTarget > parent.MaxEngagementDistance)
            {
                return ShipStateType.STATE_CHASE; // D - B (Engage -> Chase)
            }

            return base.CheckTransitions();
        }

        public override void Enter()
        {
            parent.Velocity = Vector2.Zero;
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}