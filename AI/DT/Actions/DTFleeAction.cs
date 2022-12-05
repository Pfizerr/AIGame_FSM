using Microsoft.Xna.Framework;

namespace AIGame
{
    public class DTFleeAction : DecisionTreeAction
    {
        private AIShip parent;

        public DTFleeAction(AIShip parent)
        {
            this.parent = parent;
        }

        public override void DoBehaviour(GameTime gameTime)
        {
            Vector2 dpos = Vector2.Normalize(parent.Target.Position - parent.Position);
            parent.Velocity = dpos * parent.MaxSpeed * -1;

            parent.LastAction = this;
        }
    }
}