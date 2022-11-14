using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AIGame
{
    public class ShipStateMachine : ShipState
    {
        private List<ShipState> states;
        private ShipState defaultState;
        private ShipState currentState;

        public ShipState DefaultState
        {
            get
            {
                return defaultState;
            }
            private set
            {
                defaultState = value;
            }
        }

        public ShipState CurrentState
        {
            get
            {
                return currentState;
            }
            private set
            {
                currentState = value;
            }
        }

        public ShipStateMachine(ShipStateType type, AIShip parent) : base(type, parent)
        {
            states = new List<ShipState>();
        }

        public void UpdateMachine(GameTime gameTime)
        {
            if (states.Count == 0)
                return;

            if (currentState == null)
                currentState = defaultState;

            if (defaultState == null)
                return;

            ShipStateType prevState = currentState.Type;
            ShipStateType nextState = currentState.CheckTransitions();

            if (nextState != prevState)
            {
                TransitionState(nextState);
            }

            currentState.Update(gameTime);
        }

        public void AddState(ShipState state)
        {
            states.Add(state);
        }

        public void SetDefaultState(ShipStateType stateType)
        {
            foreach (ShipState behavior in states)
            {
                if (behavior.Type == stateType)
                {
                    defaultState = behavior;
                    return;
                }
            }
        }

        public void TransitionState(ShipStateType type)
        {
            foreach (var state in states)
            {
                if (state.Type == type)
                {
                    currentState.Exit();
                    currentState = state;
                    currentState.Enter();
                }
            }
        }

        public void Reset()
        {

        }
    }
}