namespace Calculator.Calculations
{
    class EvenOdd : ICalculation
    {

        public string Compute(int number)
        {
            string evenOdd = (number % 2 == 0) ? "Even" : "Odd";

            return evenOdd;
        }
    }
}