using Microsoft.Xna.Framework.Graphics;

namespace AIGame
{
    public abstract class DecisionTreeNode
    {
        public abstract DecisionTreeNode MakeDecision();
        
        public virtual void Draw(SpriteBatch spriteBatch)
        { // draw tree (..)

        }
    }
}