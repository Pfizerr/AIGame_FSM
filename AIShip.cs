using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
	public class AIShip : Ship
    {
        private ShipStateMachine stateMachine;

        public float DistanceToTarget
        {
            get;
            private set;
        }

        public float MinDetectionDistance
        {
            get;
            private set;
        }

        public float MinEngagementDistance
        {
            get;
            private set;
        }

        public float MaxEngagementDistance
        {
            get;
            private set;
        }

        public float MinEngagementHealth
        {
            get;
            private set;
        }

        public Entity Target
        {
            get;
            private set;
        }

        public float AngleToTarget
        {
            get;
            private set;
        }
        

        public AIShip(Entity target, Vector2 position, Point size, Texture2D texture, float speed) : base(position, size, texture, speed)
        {
            Target = target;
            
            MinDetectionDistance = 250;
            MinEngagementDistance = 25;
            MaxEngagementDistance = 30;

            health = 100;
            maxHealth = 200;
            MinEngagementHealth = 50;


            stateMachine = new ShipStateMachine(ShipStateType.STATE_MACH_MAIN, this);
            stateMachine.AddState(new RoamState(this, target));
            stateMachine.AddState(new FleeState(this, target));
            stateMachine.AddState(new ChaseState(this, target));
            stateMachine.AddState(new EngageState(this, target));
            stateMachine.SetDefaultState(ShipStateType.STATE_ROAM);
        }

        public override void Update(GameTime gameTime)
        {
            DistanceToTarget = Vector2.Distance(Target.Position, Position);
            stateMachine.UpdateMachine(gameTime);

            if (KeyMouseReader.LeftClick() && boundingBox.Contains(KeyMouseReader.mouseState.Position))
            {
                health -= 10;
            }

            isActive = (health > 0);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string _debug_state_text = $"CURRENT_STATE: {stateMachine.CurrentState}\nDEFAULT_STATE: {stateMachine.DefaultState}";
            string _debug_health_text = $"HEALTH: {health}   /   MAX_HEALTH: {maxHealth}";
            string _debug_combat_text = $"DPS: {0}\nCD: {0}";
            spriteBatch.DrawString(Game1.font, _debug_state_text, new Vector2(position.X - size.X/2, position.Y + 20), Color.Yellow);
            spriteBatch.DrawString(Game1.font, _debug_health_text, new Vector2(position.X - size.X/2, position.Y - 30), Color.Yellow);
            spriteBatch.DrawString(Game1.font, _debug_combat_text, new Vector2(position.X + 25, position.Y-size.Y/2), Color.Yellow);
            base.Draw(spriteBatch);
        }
    }
}