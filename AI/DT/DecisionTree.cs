using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AIGame
{
    public class DecisionTree
    {
        //private AIShip parent;
        private DecisionTreeNode root;

        public DecisionTree(DecisionTreeNode tree)
        {
            root = tree;
        }

        public void Update(GameTime gameTime) => (root.MakeDecision() as DecisionTreeAction).DoBehaviour(gameTime);


    }
}