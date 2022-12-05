using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AIGame
{
    public abstract class AIMachine : FSMState
    {
        public AIMachine(ShipStateType type, AIShip parent) : base(type, parent)
        {

        }

        public abstract void UpdateMachine(GameTime gameTime);
        public abstract void AddState(FSMState state);
        public abstract void SetDefaultState(ShipStateType stateType);
        public abstract void TransitionState(ShipStateType type);
        public abstract void Reset();
    }
}

