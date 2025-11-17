using System;
using SmoothingFunction;

class Program
{
    static void Main(string[] args)
    {
        // Example 1 details
        float[] firstArray = { 50, 60, 40, 30, 90, -5, 40, 50, 30, 40 };
        int firstP = 3;
        float firstAlpha = 0.4F;

        //Example 2 details
        float[] secondArray = { 15, 20, 16, 90, -90, -5, 17, 19, 16, 18 };
        int secondP = 4;
        float secondAlpha = 0.5F;

        IFunction smoothingOne = new SmoothingFunction(firstP, firstAlpha);
        FunctionImplementation runFirstFunction = new FunctionImplementation(firstArray, smoothingOne);
        runFirstFunction.Calculate();

        IFunction smoothingTwo = new SmoothingFunction(secondP, secondAlpha);
        FunctionImplementation runSecondFunction = new FunctionImplementation(secondArray, smoothingTwo);
        runSecondFunction.Calculate();
    }
}