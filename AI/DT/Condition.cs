namespace AIGame
{
    public class Condition : Decision
    {
        public Decision Positive { get; private set; }
        public Decision Negative { get; private set; }

        public Condition(Decision positive, Decision negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public override void Evaluate(object context)
        {
            bool result = true;
            //evaluation..

            if (result)
            {
                Positive.Evaluate(context);
            }
            else
            {
                Negative.Evaluate(context);
            }

        }
    }
}