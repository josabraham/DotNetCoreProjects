This example shows a  .NET Core console application and a library, then call a library function from the console application while taking command-line arguments.

The CompEngine class implements the different compute operations such as "Add","Sub","Mul" and "Div".

The computetion operations are performed via a Dispatcher class which implements the DoDispath function.
The input to dispatcher is a OPERATION_INPUT type and the DoDispatch return a OPERATION_RESULT type as result.

Run the following commands to restore dependencies and build the solution:
```
dotnet restore
dotnet build
```

Step 6: Run the Console Application:
Run the console application with a command-line argument:

```
dotnet run --project MyConsoleApp/MyConsoleApp.csproj add 2 3
```

You should see the output:
```
Result Value = 5
```
Other computation operations can be performed similarly.