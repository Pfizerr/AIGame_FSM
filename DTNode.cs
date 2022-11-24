using System.Collections.Generic;

namespace AIGame
{
    public abstract class Decision
    {
        public abstract void Evaluate(object context);
    }

	public class Node : Decision
    {
        public Decision Positive { get; private set; }
        public Decision Negative { get; private set; }

        public override void Evaluate(object context)
        {
            bool result = true;
            //evaluation..

            if(result)
            {
                Positive.Evaluate(context);
            }
            else
            {
                Negative.Evaluate(context);
            }

        }
    }

    public class Leaf : Decision
    {
        public override void Evaluate(object context)
        {
        }
    }
}