namespace AIGame
{
	public class ChaseState : ShipState
    {
        public ChaseState(AIShip parent) : base(ShipStateType.STATE_CHASE, parent)
        {
        }

        public override void Update()
        {

            base.Update();
        }

        public override ShipStateType CheckTransitions()
        {
            if (parent.DistanceToTarget > parent.DetectionRadius)
            {
                return ShipStateType.STATE_ROAM; // B - A, (Chase -> Roam)
            }
            else
            {
                if (parent.Health < parent.MinEngagementHealth)
                {
                    return ShipStateType.STATE_FLEE; // B - C, (Chase -> Flee)
                }
                if (parent.DistanceToTarget < parent.EngagementRadius)
                {
                    return ShipStateType.STATE_ENGAGE; // B - D, (Chase -> Engage)
                }
            }

            return base.CheckTransitions();
        }
    }
}