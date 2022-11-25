using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AIGame
{
    public class FSMMachine : AIMachine
    {
        private List<FSMState> states;
        private FSMState defaultState;
        private FSMState currentState;

        public FSMState DefaultState
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

        public FSMState CurrentState
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

        public FSMMachine(ShipStateType type, AIShip parent) : base(type, parent)
        {
            states = new List<FSMState>();
        }

        public override void UpdateMachine(GameTime gameTime)
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

        public override void AddState(FSMState state)
        {
            states.Add(state);
        }

        public override void SetDefaultState(ShipStateType stateType)
        {
            foreach (FSMState behavior in states)
            {
                if (behavior.Type == stateType)
                {
                    defaultState = behavior;
                    return;
                }
            }
        }

        public override void TransitionState(ShipStateType type)
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

        public override void Reset()
        {

        }
    }
}