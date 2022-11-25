namespace AIGame
{
    public class DTReadyToEngageDecision : DecisionTreeDecision
    {
        private AIShip parent;

        public DTReadyToEngageDecision(AIShip parent) : base()
        {
            this.parent = parent;
        }

        public override DecisionTreeNode GetBranch()
        {
            if (parent.Health > parent.MinEngagementHealth)
            {
                return TrueBranch;
            }

            return FalseBranch;
        }
    }
}