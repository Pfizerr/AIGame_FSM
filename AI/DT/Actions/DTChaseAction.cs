using Microsoft.Xna.Framework;

namespace AIGame
{
    public class DTChaseAction : DecisionTreeAction
    {
        private AIShip parent;

        public DTChaseAction(AIShip parent)
        {
            this.parent = parent;
        }

        public override void DoBehaviour(GameTime gameTime)
        {
            Vector2 dpos = Vector2.Normalize(parent.Target.Position - parent.Position);
            parent.Velocity = dpos * parent.MaxSpeed;

            parent.LastAction = this;
        }
    }
}