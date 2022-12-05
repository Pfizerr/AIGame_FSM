using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace AIGame
{
	public class AIShip : Ship
    {
        private bool DEBUG_DT = false;
        private bool DEBUG_FSM = true;

        public DecisionTreeAction LastAction { get; set; }

        private FSMMachine stateMachine;
        private DecisionTree decisionTree;

        public float MaxEngagementDistance { get; private set; }
        public float MinEngagementDistance { get; private set; }
        public float MinDetectionDistance { get; private set; }
        public float MinEngagementHealth { get; private set; }
        public float DistanceToTarget { get; private set; }
        public float AngleToTarget { get; private set; }
        public Entity Target { get; private set; }



        public AIShip(Entity target, Vector2 position, Point size, Texture2D texture, float speed) : base(position, size, texture, speed)
        {
            Target = target;

            MinDetectionDistance = 250;
            MinEngagementDistance = 25;
            MaxEngagementDistance = 30;
            health = 100;
            maxHealth = 200;
            MinEngagementHealth = 50;

            DTTargetDetectableDecision targetDetectable = new DTTargetDetectableDecision(this);
            DTReadyToEngageDecision readyToEngage = new DTReadyToEngageDecision(this);
            DTTargetNearDecision targetNear = new DTTargetNearDecision(this);
            DTEngageAction engage = new DTEngageAction(this);
            DTChaseAction chase = new DTChaseAction(this);
            DTFleeAction flee = new DTFleeAction(this);
            DTRoamAction roam = new DTRoamAction(this);
            targetNear.TrueBranch = engage;
            targetNear.FalseBranch = chase;
            readyToEngage.TrueBranch = targetNear;
            readyToEngage.FalseBranch = flee;
            targetDetectable.TrueBranch = readyToEngage;
            targetDetectable.FalseBranch = roam;
            decisionTree = new DecisionTree(targetDetectable);
            LastAction = roam;

            stateMachine = new FSMMachine(ShipStateType.FSM_STATE_MACH_MAIN, this);
            stateMachine.AddState(new FSMRoamState(this, target));
            stateMachine.AddState(new FSMFleeState(this, target));
            stateMachine.AddState(new FSMChaseState(this, target));
            stateMachine.AddState(new FSMEngageState(this, target));
            stateMachine.SetDefaultState(ShipStateType.FSM_STATE_ROAM);
        }

        public override void Update(GameTime gameTime)
        {
            DistanceToTarget = Vector2.Distance(Target.Position, Position);

            if (DEBUG_DT)
            {
                if (KeyMouseReader.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
                {
                    DEBUG_DT = false;
                    DEBUG_FSM = true;
                }
                decisionTree.Update(gameTime);
            }
            else if (DEBUG_FSM)
            {
                if (KeyMouseReader.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
                {
                    DEBUG_FSM = false;
                    DEBUG_DT = true;
                }
                stateMachine.UpdateMachine(gameTime);
            }

            if (KeyMouseReader.LeftClick() && boundingBox.Contains(KeyMouseReader.mouseState.Position))
            {
                health -= 10;
            }

            isAlive = (health > 0);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string healthText = $"HEALTH: {health}   /   MAX_HEALTH: {maxHealth}";
            spriteBatch.DrawString(Game1.font, healthText, new Vector2(position.X - size.X / 2, position.Y - 30), Color.Yellow);

            string fsmDebugText = $"FSM: {DEBUG_FSM}\nState: {stateMachine.CurrentState}\nDefault: {stateMachine.DefaultState}";
            spriteBatch.DrawString(Game1.font, fsmDebugText, new Vector2(100, 20), Color.Blue);
        
            string dtDebugText = $"DT: {DEBUG_DT}\nLast Behaviour: {LastAction.GetType().Name}";
            spriteBatch.DrawString(Game1.font, dtDebugText, new Vector2(300, 20), Color.Red);

            spriteBatch.DrawString(Game1.font, "Press space to switch between DT/FSM.", new Vector2(100, 80), Color.White);


            base.Draw(spriteBatch);
        }
    }
}