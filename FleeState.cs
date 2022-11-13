namespace AIGame
{
	public class FleeState : ShipState
    {

        public FleeState(AIShip parent) : base(ShipStateType.STATE_FLEE, parent)
        {
        }

        public override void Update()
        {

            base.Update();
        }

        public override ShipStateType CheckTransitions()
        {
            
            return base.CheckTransitions();
        }
    }
}