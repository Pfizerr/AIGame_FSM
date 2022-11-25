using Microsoft.Xna.Framework;

namespace AIGame
{
    public abstract class DecisionTreeAction : DecisionTreeNode
    {
        public abstract void DoBehaviour(GameTime gameTime);
        public override DecisionTreeNode MakeDecision() => this;
    }
}