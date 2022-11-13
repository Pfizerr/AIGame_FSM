namespace AIGame
{
	public abstract class ShipState
    {
        protected AIShip parent;

        public virtual ShipStateType Type
        {
            get;
            protected set;
        }


        public ShipState(ShipStateType type, AIShip parent)
        {
            this.parent = parent;
            Type = type;
        }

        public virtual void Update()
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