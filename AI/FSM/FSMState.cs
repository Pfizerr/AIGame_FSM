using Microsoft.Xna.Framework;

namespace AIGame
{
	public abstract class FSMState
    {
        protected AIShip parent;

        public virtual ShipStateType Type
        {
            get;
            protected set;
        }


        public FSMState(ShipStateType type, AIShip parent)
        {
            this.parent = parent;
            Type = type;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual ShipStateType CheckTransitions()
        {
            return Type;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }
    }

   
}