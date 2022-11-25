using Microsoft.Xna.Framework;

namespace AIGame
{
    public abstract class ShipBehaviour
    {
        protected AIShip parent;

        public ShipBehaviour(AIShip parent)
        {
            this.parent = parent;
        }

        public abstract void DoBehaviour(GameTime gameTime);
    }
}