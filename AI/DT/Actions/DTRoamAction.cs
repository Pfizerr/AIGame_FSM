using Microsoft.Xna.Framework;

namespace AIGame
{
    public class DTRoamAction : DecisionTreeAction
    {
        private AIShip parent;

        public DTRoamAction(AIShip parent)
        {
            this.parent = parent;
        }

        public override void DoBehaviour(GameTime gameTime)
        {
            float dt = (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f);

            if (parent.Velocity.Length() < parent.MaxSpeed * 0.1f)
            {
                parent.Velocity = Vector2.Zero;
            }
            else
            {
                parent.Velocity -= parent.Velocity * 0.5f * dt;
            }
        }
    }
}