using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace AIGame
{
    public class Cursor : Entity
    {
        public bool IsTargetable
        {
            get;
            private set;
        }

        public Cursor(Point size, Texture2D texture) : base(Vector2.Zero, size, 0.0f, texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Position = KeyMouseReader.mouseState.Position.ToVector2();

            Debug.WriteLine(Position);

            if(KeyMouseReader.KeyHold(Keys.Space))
            {
                IsTargetable = true;
            }
            else
            {
                IsTargetable = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
