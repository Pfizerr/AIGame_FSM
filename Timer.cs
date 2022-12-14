using Microsoft.Xna.Framework;

namespace AIGame
{
	public class Timer
    {
        private int interval;
        private double start;

        public Timer(int interval)
        {
            this.interval = interval;
        }

        public bool IsDone(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds >= interval + start)
            {
                return true;
            }

            return false;
        }

        public void Start(GameTime gameTime)
        {
            start = gameTime.TotalGameTime.TotalMilliseconds;
        }

        public void Restart(GameTime gameTime)
        {
            Start(gameTime);
        }
    }
}