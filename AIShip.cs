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

        public float DetectionRadius
        {
            get;
            private set;
        }

        public float EngagementRadius
        {
            get;
            private set;
        }

        public float MinEngagementHealth
        {
            get;
            private set;
        }

        public Ship Target
        {
            get;
            private set;
        }
        

        public AIShip(Ship target, Vector2 position, Point size, Texture2D texture, float speed) : base(position, size, texture, speed)
        {
            Target = target;
            
            DetectionRadius = 500;
            EngagementRadius = 25;
            MinEngagementHealth = 50;

            stateMachine = new ShipStateMachine(ShipStateType.STATE_MACH_MAIN, this);
            stateMachine.AddState(new RoamState(this));
            stateMachine.AddState(new FleeState(this));
            stateMachine.AddState(new ChaseState(this));
            stateMachine.AddState(new EngageState(this));
            stateMachine.SetDefaultState(ShipStateType.STATE_ROAM);
        }

        public override void Update(GameTime gameTime)
        {
            DistanceToTarget = Vector2.Distance(Target.Position, Position);


            base.Update(gameTime);
        }
    }
}