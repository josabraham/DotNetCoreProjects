
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CompEngine;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.ConfigureServices(services =>
                            {
                                services.AddControllers();
                            });

                            webBuilder.Configure(app =>
                            {
                                app.UseRouting();
                                app.UseEndpoints(endpoints =>
                                {
                                    endpoints.MapControllers();
                                });
                            });
                        });
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
