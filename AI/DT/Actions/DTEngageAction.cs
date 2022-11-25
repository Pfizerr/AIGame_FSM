using Microsoft.Xna.Framework;

namespace AIGame
{
    public class EngageBehaviour : ShipBehaviour
    {
        public EngageBehaviour(AIShip parent) : base(parent)
        {
        }

        public override void DoBehaviour(GameTime gameTime)
        {
            parent.Velocity = Vector2.Zero;
        }
    }

    public class DTEngageAction : DecisionTreeAction
    {
        private AIShip parent;
    
        public DTEngageAction(AIShip parent)
        {
            this.parent = parent;
        }
    
        public override void DoBehaviour(GameTime gameTime)
        {
            parent.Velocity = Vector2.Zero;
        }
    }
}