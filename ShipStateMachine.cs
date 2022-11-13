using System.Collections.Generic;

namespace AIGame
{
    public class ShipStateMachine : ShipState
    {
        private List<ShipState> states;
        private ShipState defaultState;
        private ShipState currentState;

        public ShipStateMachine(ShipStateType type, AIShip parent) : base(type, parent)
        {
            states = new List<ShipState>();
        }

        public void UpdateMachine()
        {
            if (states.Count == 0)
                return;

            if (currentState == null)
                currentState = defaultState;

            if (defaultState == null)
                return;



            currentState.Update();
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
                    currentState = state;
                }
            }
        }

        public void Reset()
        {

        }
    }
}