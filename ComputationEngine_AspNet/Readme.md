This .Net Core example show how to self-host a .NET Core Console Application using ASP.NET Core's Kestrel web server. This approach allows you to run a console application that hosts an ASP.NET Core web server. Below are the steps to create such an application and host it:

Step 1: Create the Console Application

1. Create a New Console Application:
Open your terminal and run the following commands to create a new Console Application project:

    ```
    dotnet new console -n MyConsoleApp
    cd MyConsoleApp
    ```

2. Add ASP.NET Core Packages:
    ```
    dotnet add package Microsoft.AspNetCore
    dotnet add package Microsoft.AspNetCore.Hosting
    dotnet add package Microsoft.Extensions.Hosting
    ```

3. Modify the Program.cs File main:

    ```
    public class Program
        {
            public static void Main(string[] args)
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
    ```
Also Add the Controller

Please see the Program.cs in the example for the entire source code

4. Add ASP.NET Core MVC Package:

To use controllers, you need to add the MVC package:
    ```
    dotnet add package Microsoft.AspNetCore.Mvc
    ```

5. Run the Application:
    Build and run the console application:
    ```
    dotnet run
    ```
    By default, the application will be hosted on https://localhost:5001 or http://localhost:5000.

Step 2: Call the API Using Postman
Open Postman:
Open Postman, which you can download from Postman if you haven't already.
Send a GET Request to Find a String:
URL: http://localhost:5000/api/compengine/calculate?operation=add&operand1=5&operand2=3
Method: GET
Send the Request: Click the "Send" button.
You should receive a response with the result 8 with above parameters.
