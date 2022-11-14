using Microsoft.Xna.Framework;

namespace AIGame
{
    public class ShipBehaviour : ShipState
    {
        public virtual AIShip AIShip
        {
            get
            {
                return (parent as AIShip);
            }
            protected set
            {
                parent = value;
            }
        }

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
