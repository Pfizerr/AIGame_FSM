using Microsoft.Xna.Framework;

namespace AIGame
{
    public abstract class AIMachine
    {
        public AIMachine()
        {
        }

        public abstract void Update(GameTime gameTime);
        public abstract void UpdateMachine(GameTime gameTime);
        public abstract void Reset();
    }
}