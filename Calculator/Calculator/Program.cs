using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0; int b = 0;
            Console.WriteLine("\nThis is the calculator app!\n");
            Console.WriteLine("Enter your first number");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your second number");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nHere are your options...\n");
            Console.WriteLine("Type 1 to add the numbers");
            Console.WriteLine("Type 2 to subtract the numbers");
            Console.WriteLine("Type 3 to multiply the numbers");
            Console.WriteLine("Type 4 to divide the numbers");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("The result is " + (a + b));
                    break;
                case "2":
                    Console.WriteLine("The result is " + (a - b));
                    break;
                case "3":
                    Console.WriteLine("The result is " + (a * b));
                    break;
                case "4":
                    Console.WriteLine("The result is " + (a / b));
                    break;
            }

            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();

        }
    }
}
