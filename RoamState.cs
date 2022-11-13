namespace AIGame
{
	public class RoamState : ShipState
    {
        public RoamState(AIShip parent) : base(ShipStateType.STATE_ROAM, parent)
        {
        }

        public override void Update()
        {

            

            base.Update();
        }

        public override ShipStateType CheckTransitions()
        {
            if (parent.DistanceToTarget < parent.DetectionRadius)
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