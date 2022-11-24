using Microsoft.Xna.Framework;

namespace AIGame
{
    public abstract class AIController
    {
        public AIController()
        {
        }

        public abstract void Update(GameTime gameTime);
        public abstract void UpdatePerception(GameTime gameTime);
    }
}