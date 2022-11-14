using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
    public class Cursor : Entity
    {
        private Texture2D texture;
        private Point size;

        public bool IsTargetable
        {
            get;
            private set;
        }

        public Cursor( Point size, Texture2D texture) : base(Vector2.Zero)
        {
            this.texture = texture;
            this.size = size;
        }

        public void Update()
        {
            Position = KeyMouseReader.mouseState.Position.ToVector2();

            if(KeyMouseReader.KeyHold(Keys.Space))
            {
                IsTargetable = true;
            }
            else
            {
                IsTargetable = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, size.ToVector2() * 0.5f, 1f, SpriteEffects.None, 0f);
        }
    }
}
