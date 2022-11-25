namespace AIGame
{
    public class DTTargetNearDecision : DecisionTreeDecision
    {
        private AIShip parent;

        public DTTargetNearDecision(AIShip parent) : base()
        {
            this.parent = parent;
        }

        public override DecisionTreeNode GetBranch()
        {
            if (parent.DistanceToTarget < parent.MinEngagementDistance)
            {
                return TrueBranch;
            }

            return FalseBranch;
        }
    }
}