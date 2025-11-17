using System;

namespace SmoothingFunction
{
    class SmoothingFunction : IFunction
    {
        private int _p;
        private float _alpha;

        public SmoothingFunction(int p, float alpha)
        {
            _p = p;
            _alpha = alpha;
        }

        public float[] Calculate(float[] input)
        {
            float[] s = new float[input.Length];

            s[0] = FirstValue(input);

            for (int i = 1; i < input.Length; i++)
            {
                s[i] = SubsequentValues(input[i], s[i - 1]);
            }

            return s;

        }

        private float FirstValue(float[] input)
        {
            float value = 0;

            for (int i = 0; i < _p; i++)
            {
                value += input[i];
            }

            value /= _p;

            return Math.Max(value, 0);
        }

        private float SubsequentValues(float next, float previous)
        {
            float value = (_alpha * next) + ((1 - _alpha) * previous);

            return Math.Max(value, 0);
        }
    }
}