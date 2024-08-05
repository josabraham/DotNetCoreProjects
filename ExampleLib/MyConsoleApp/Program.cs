using System;
using MyLibrary;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a name as a command-line argument.");
                return;
            }

            string name = args[0];
            MyClass myClass = new MyClass();
            string greeting = myClass.Greet(name);

            Console.WriteLine(greeting);
        }
    }
}
