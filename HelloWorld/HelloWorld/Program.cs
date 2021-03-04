using System;

namespace AV.ProgrammingWithCSharp.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Hello " + args[0] + "!");
            }
            else
            {
                Console.WriteLine("This application expects to receive name as a parameter. Please type in your name and press Enter to receive a message\"Hello [Your Name]!\" " +
                    "or press Enter to receive a message \"Hello!\"");
                string userInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Hello!");
                }
                else
                {
                    Console.WriteLine($"Hello {userInput}!");
                }
            }            
        }
    }
}
