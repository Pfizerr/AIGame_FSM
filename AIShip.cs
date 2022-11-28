using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace AIGame
{
	public class AIShip : Ship
    {
        //private FSMMachine stateMachine;
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

            #region DT
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
            #endregion

            #region FSM
            //stateMachine = new FSMMachine(ShipStateType.FSM_STATE_MACH_MAIN, this);
            //stateMachine.AddState(new FSMRoamState(this, target));
            //stateMachine.AddState(new FSMFleeState(this, target));
            //stateMachine.AddState(new FSMChaseState(this, target));
            //stateMachine.AddState(new FSMEngageState(this, target));
            //stateMachine.SetDefaultState(ShipStateType.FSM_STATE_ROAM);
            #endregion
        }

        public override void Update(GameTime gameTime)
        {
            DistanceToTarget = Vector2.Distance(Target.Position, Position);
            Debug.WriteLine(Target.Position);


            #region DT
            decisionTree.Update(gameTime);
            #endregion

            #region FSM
            //stateMachine.UpdateMachine(gameTime);
            #endregion

            if (KeyMouseReader.LeftClick() && boundingBox.Contains(KeyMouseReader.mouseState.Position))
            {
                health -= 10;
            }

            isAlive = (health > 0);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //string _debug_state_text = $"CURRENT_STATE: {stateMachine.CurrentState}\nDEFAULT_STATE: {stateMachine.DefaultState}";
            string _debug_health_text = $"HEALTH: {health}   /   MAX_HEALTH: {maxHealth}";
            string _debug_combat_text = $"DPS: {0}\nCD: {0}";
            //spriteBatch.DrawString(Game1.font, _debug_state_text, new Vector2(position.X - size.X/2, position.Y + 20), Color.Yellow);
            spriteBatch.DrawString(Game1.font, _debug_health_text, new Vector2(position.X - size.X/2, position.Y - 30), Color.Yellow);
            spriteBatch.DrawString(Game1.font, _debug_combat_text, new Vector2(position.X + 25, position.Y-size.Y/2), Color.Yellow);
            base.Draw(spriteBatch);
        }
    }
}