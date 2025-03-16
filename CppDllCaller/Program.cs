using System;
using System.Runtime.InteropServices;

class Program
{
    // Importing the Multiply function from MultiplyLibrary.dll
    [DllImport("MultiplyLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Multiply(int a, int b);

    static void Main()
    {
        try
        {
            Console.Write("Enter first integer: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            int result = Multiply(num1, num2);

            if (result == 0 && num1 != 0 && num2 != 0)
            {
                Console.WriteLine("Error: Multiplication overflow occurred.");
            }
            else
            {
                Console.WriteLine($"Result: {num1} * {num2} = {result}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid integers.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Input number is too large.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
