using System;
using CompEngine;

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
            if (args.Length != 3)
            {

                Console.WriteLine("Insufficient number of arguments.");
                return;
            }

            string op_name = args[0];
            int first_op = int.Parse(args[1]);
            int second_op = int.Parse(args[2]);

            OPERATION_INPUT input;
            input.operation_name = op_name;
            input.op_a = first_op;
            input.op_b = second_op;


            Operation_Dispatcher dispatcher=new Operation_Dispatcher();
            OPERATION_RESULT result = dispatcher.DoDispatch(input);
            Console.WriteLine("Result Value " + result.return_value );
        }
    }

    public struct OPERATION_RESULT
    {
        public bool status;
        public string result_status;
        public int return_value;
    }

    public struct OPERATION_INPUT
    {
        public string operation_name;
        public int op_a;
        public int op_b;
    }

    public class Operation_Dispatcher
    {
        public MyCompEngine compEngine = new MyCompEngine();

        public OPERATION_RESULT DoDispatch(OPERATION_INPUT input)
        {
            List<string> commandTypes = new List<string> {"ADD","SUB","MUL","DIV"};

            string searchString = input.operation_name;
            string op_name = commandTypes.FirstOrDefault(item => item == searchString);

            OPERATION_RESULT result=new OPERATION_RESULT();

             if (op_name == null)
             {
                Console.WriteLine($"Item '{searchString}' not found in the list.");
                result.status = false;
                return result;
             }
            else 
            {
                Console.WriteLine($"Item '{op_name}' found in the list.");
                switch(op_name)
                {
                    case "ADD":
                        result.return_value = compEngine.Add(input.op_a,input.op_b);
                        result.status = true;
                        break;
                    case "SUB":
                        result.return_value = compEngine.Sub(input.op_a,input.op_b);
                        result.status = true;
                        break;
                    case "MUL":
                        result.return_value = compEngine.Mul(input.op_a,input.op_b);
                        result.status = true;
                        break;
                    case "DIV":
                        result.return_value = compEngine.Div(input.op_a,input.op_b);
                        result.status = true;
                        break;
                    default:result.status = false;
                        break;
                }
                 return result;
            }
        }
    }
}
