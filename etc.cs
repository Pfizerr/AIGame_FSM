/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AIGame
{
    public class AIShip : Ship
    {
        private AIBehaviour behaviour;

        public AIShip(Vector2 position, Point size, Texture2D texture) : base(position, size, texture)
        {
            behaviour = new RoamBehaviour(this);
        }

        public override void Update(GameTime gameTime)
        {
            behaviour = behaviour.Update();

            base.Update(gameTime);
        }
    }

    public class FleeBehaviour : AIBehaviour
    {
        public FleeBehaviour(AIShip parent) : base(parent)
        {

        }

        public override AIBehaviour Update()
        {
            return null;
        }

        public override AIBehaviour CheckTransitions()
        {
            return null;
        }
    }





    public class RoamBehaviour : AIBehaviour 
    {
        public RoamBehaviour(AIShip parent) : base(parent)
        {

        }

        public override AIBehaviour Update()
        {
            return null;
        }

        public override AIBehaviour CheckTransitions()
        {
            return null;
        }
    }

    public class PursueBehaviour : AIBehaviour
    {
        public PursueBehaviour(AIShip parent) : base(parent)
        {

        }

        public override AIBehaviour Update()
        {
            return null;
        }

        public override AIBehaviour CheckTransitions()
        {
            return null;
        }
    }

    public class EngageBehaviour : AIBehaviour
    {
        public EngageBehaviour(AIShip parent) : base(parent)
        {

        }

        public override AIBehaviour Update()
        {
            return null;
        }

        public override AIBehaviour CheckTransitions()
        {
            return null;
        }
    }





    public abstract class AIBehaviour
    {
        protected BehaviourType type;

        public BehaviourType Type
        {
            get
            {
                return type;
            }
            private set
            {
                type = value;
            }
        }

        protected AIShip parent;

        public AIBehaviour(AIShip parent)
        {
            this.parent = parent;
        }

        public virtual AIBehaviour Update()
        {
            return null;
        }

        public virtual AIBehaviour CheckTransitions()
        {
            return null;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

    }




    public enum BehaviourType
    {
        BEHAVIOUR_TYPE_ROAM,
        BEHAVIOUR_TYPE_PURSUE,
        BEHAVIOUR_TYPE_FLEE,
        BEHAVIOUR_TYPE_ENGAGE
    }

    public class AIStateMachine : AIBehaviour
    {
        private List<AIBehaviour> states;
        private AIBehaviour currentState;
        private AIBehaviour defaultState;

        public AIStateMachine(AIShip parent) : base(parent)
        {
            states = new List<AIBehaviour>();
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

        public void AddState(AIBehaviour state)
        {
            states.Add(state);
        }

        public void SetDefaultState(AIBehaviour subject)
        {
            foreach (var state in states)
            {
                if (state.Type == subject.Type)
                {
                    defaultState = state;
                    return;
                }
            }

            AddState(subject);
            defaultState = subject;
        }

        public void TransitionState(BehaviourType type)
        {
            foreach (var state in states)
            {
                if (state.Type == type)
                {
                    currentState = state;
                }
            }

            // No state found ..
        }

        public void Reset()
        {

        }
    }
}
*/