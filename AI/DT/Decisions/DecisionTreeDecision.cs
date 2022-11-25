namespace AIGame
{
    public abstract class DecisionTreeDecision : DecisionTreeNode
    {
        public DecisionTreeNode TrueBranch { get; set; }
        public DecisionTreeNode FalseBranch { get; set; }

        public DecisionTreeDecision()
        {
        }

        public abstract DecisionTreeNode GetBranch();

        public override DecisionTreeNode MakeDecision()
        {
            DecisionTreeNode branch = GetBranch();
            return branch.MakeDecision();
        }
    }
}