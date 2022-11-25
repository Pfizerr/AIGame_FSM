namespace AIGame
{
    public class DTTargetDetectableDecision : DecisionTreeDecision
    {
        private AIShip parent;

        public DTTargetDetectableDecision(AIShip parent) : base()
        {
            this.parent = parent;
        }

        public override DecisionTreeNode GetBranch()
        {
            if (parent.Target.IsActive)
            {
                if (parent.DistanceToTarget < parent.MinDetectionDistance)
                {
                    return TrueBranch;
                }
            }

            return FalseBranch;
        }
    }
}