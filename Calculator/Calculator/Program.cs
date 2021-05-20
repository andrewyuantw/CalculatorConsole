using System;

namespace Calculator
{
    class Program
    {

        static int Calculate(int a, int b)
        {
            Console.WriteLine("\nHere are your options...\n");
            Console.WriteLine("Type 1 to add the numbers");
            Console.WriteLine("Type 2 to subtract the numbers");
            Console.WriteLine("Type 3 to multiply the numbers");
            Console.WriteLine("Type 4 to divide the numbers");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("The result is " + (a + b));
                    return a + b;
                case "2":
                    Console.WriteLine("The result is " + (a - b));
                    return a - b;
                case "3":
                    Console.WriteLine("The result is " + (a * b));
                    return a * b;
                case "4":
                    if (b == 0)
                    {
                        Console.WriteLine("Can't divide by zero ...");
                        return Calculate(a, b);
                    }
                    else
                    {
                        Console.WriteLine("The result is " + (a / b));
                        return a / b;
                    }

                default:
                    Console.WriteLine("Invalid choice...");
                    return Calculate(a, b);
            }


        }

        static void DisplayMenu(int a, int b, int total)
        {
            Console.WriteLine("\nHere are your options...\n");
            Console.WriteLine("Type 1 to continue operations");
            Console.WriteLine("Type 2 to input two new numbers");
            Console.WriteLine("Type 3 to exit");

            switch (Console.ReadLine())
            {
                case "1":
                    a = total;
                    Console.WriteLine("Enter new number");
                    b = Convert.ToInt32(Console.ReadLine());
                    Calculate(a, b);
                    DisplayMenu(a, b, total);
                    break;
                case "2":
                    Console.WriteLine("Enter your first number");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter your second number");
                    b = Convert.ToInt32(Console.ReadLine());
                    Calculate(a, b);
                    DisplayMenu(a, b, total);
                    break;
                case "3":
                    break;

            }

        }
        static void Main(string[] args)
        {
            int a = 0; int b = 0;
            Console.WriteLine("\nThis is the calculator app!\n");
            Console.WriteLine("Enter your first number");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your second number");
            b = Convert.ToInt32(Console.ReadLine());

            int total = Calculate(a, b);
            DisplayMenu(a, b, total);
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();

        }
    }
}
