using System;
using System.Linq;

namespace SmoothingFunction
{
    class FunctionImplementation
    {
        private float[] _input;
        private IFunction _algorithm;

        public FunctionImplementation(float[] inputValues, IFunction algo)
        {
            _input = inputValues;
            _algorithm = algo;
        }

        public void Calculate()
        {
            float[] s = _algorithm.Calculate(_input);

            Console.WriteLine("x[] = {" + string.Join(", ", _input) + "}");

            Console.WriteLine("s[] = {" + string.Join(", ", s.Select(n => n.ToString("F2"))) + "}");

            Console.WriteLine("__________________________________________________");
        }

    }
}