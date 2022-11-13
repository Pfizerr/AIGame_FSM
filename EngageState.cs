namespace AIGame
{
	public class EngageState : ShipState
    {
        public EngageState(AIShip parent) : base(ShipStateType.STATE_ENGAGE, parent)
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