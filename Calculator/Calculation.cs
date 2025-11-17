using System.Numerics;

namespace Calculator
{

    class Calculation
    {

        private ICalculation _selectedCalculation;
        private int _inputValue;

        public Calculation(ICalculation calculation, int value)
        {
            _selectedCalculation = calculation;
            _inputValue = value;

        }

        public string Calculate()
        {
            return _selectedCalculation.Compute(_inputValue);
        }

    }
}