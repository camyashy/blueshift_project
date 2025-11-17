using System;
using System.Formats.Asn1;
using System.Linq;
using Calculator.Calculations;

namespace Calculator
{

    class CalculationConsole
    {
        public static readonly string[] CalculationModeOptions = { "copy", "factorial", "evenodd", "exit" };
        public static readonly string WelcomeMessage = "Please select your calculation mode:\n" + string.Join("\n", CalculationModeOptions) + "Type 'exit' at any time to leave the console";
        public static void Run()
        {
            string calculationMode;
            int value;
            ICalculation calculationMethod;
            Calculation computationManager;
            string result;

            Console.WriteLine("Welcome to the Calculation Console");

            while (true)
            {

                calculationMode = GetCalculationMode();

                if (calculationMode == "exit")
                {
                    return;
                }

                value = GetValue();

                if (value == int.MinValue)
                { // Aka "exit" has been entered
                    return;
                }

                calculationMethod = GetICalculation(calculationMode);
                computationManager = new Calculation(calculationMethod, value);

                result = computationManager.Calculate();
                Console.WriteLine($"The result: {result}");
                Console.WriteLine("________________________________________");
            }
        }

        private static string GetCalculationMode()
        {

            string? input = null;

            Console.WriteLine(WelcomeMessage);

            do
            {

                try
                {
                    input = Console.ReadLine();

                }
                catch (Exception)
                {
                    Console.WriteLine("Error with I/O Stream. Please try again.");
                    continue;
                }

                if (input != null)
                {
                    input = input.ToLower();
                }


                if (!CalculationModeOptions.Contains(input))
                {
                    input = null;
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            } while (input == null);

            return input;
        }

        private static int GetValue()
        {

            string? input = null;
            int value = int.MinValue;

            Console.WriteLine("Please enter a number greater or equal to 1 for your calculation.");

            do
            {

                // Gets the input as a string and determines if "exit" was entered
                while (input == null)
                {
                    try
                    { // This accounts for errors in the I/O action
                        input = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        input = null;
                        Console.WriteLine("Error with I/O Stream. Please try again.");
                        continue;
                    }
                }

                // Attempts to convert the input to an int
                // If unable, it is an invalid entry and the while loop continues
                try
                {

                    // Determine if the user wants to exit
                    input = input.ToLower();

                    if (input == "exit")
                    {
                        return value;
                    }

                    value = int.Parse(input);

                    if (value < 1)
                    {
                        throw new Exception("Value must be greater than or equal to 1");
                    }
                }
                catch (Exception)
                { // If the entry is unable to be cast to an int, it will prompt to try again
                    input = null;
                    Console.WriteLine("You have not entered a valid number. Please try again.");
                }
            } while (input == null);

            return value;
        }

        private static ICalculation GetICalculation(string calculationType)
        {

            ICalculation newCalculation;

            newCalculation = calculationType switch
            {
                "copy" => new Copy(),
                "factorial" => new Factorial(),
                "evenodd" => new EvenOdd(),
                _ => throw new Exception("Invalid calculation type provided")

            };

            return newCalculation;
        }
    }
}