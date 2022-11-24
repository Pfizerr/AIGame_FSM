using Microsoft.Xna.Framework;

namespace AIGame
{
    public class ShipBehaviour : ShipState
    {
        public ShipBehaviour(ShipStateType type, AIShip parent) : base(type, parent)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override ShipStateType CheckTransitions()
        {
            return base.CheckTransitions();
        }
    }
}
