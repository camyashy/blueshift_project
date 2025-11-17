namespace Calculator.Calculations
{
    class Factorial : ICalculation
    {

        public string Compute(int number)
        {
            int calculation = number;

            for (int i = number - 1; i > 1; i--)
            {
                calculation *= i;
            }

            return calculation.ToString();
        }
    }
}