namespace Calculator.Calculations
{
    class Copy : ICalculation
    {

        public string Compute(int number)
        {
            return number.ToString();
        }
    }
}