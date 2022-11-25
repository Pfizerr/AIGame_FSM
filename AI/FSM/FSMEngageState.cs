using Microsoft.Xna.Framework;

namespace AIGame
{
	public class FSMEngageState : FSMState
    {
        private Entity target;

        public FSMEngageState(AIShip parent, Entity target) : base(ShipStateType.FSM_STATE_ENGAGE, parent)
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
                return ShipStateType.FSM_STATE_ROAM; // D - A (Engage -> Roam)
            }

            else if (parent.Health < parent.MinEngagementHealth)
            {
                return ShipStateType.FSM_STATE_FLEE; // D - C (Engage -> Flee)
            }

            else if (parent.DistanceToTarget > parent.MaxEngagementDistance)
            {
                return ShipStateType.FSM_STATE_CHASE; // D - B (Engage -> Chase)
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