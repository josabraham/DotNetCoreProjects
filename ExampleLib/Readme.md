Let's walk through the steps to create a .NET Core console application and a library, then call a library function from the console application while taking command-line arguments.


Step 1: Create the Solution and Projects
Create a Solution:
Open your terminal and navigate to the directory where you want to create your solution. Run the following command:

```
dotnet new sln -n MySolution
cd MySolution 
```

Step2: Create the Library Project:
Create a class library project:

```
dotnet new classlib -n MyLibrary
dotnet sln add MyLibrary/MyLibrary.csproj
```

Step3: Create the Console Application Project:
Create a console application project:
```
dotnet new console -n MyConsoleApp
dotnet sln add MyConsoleApp/MyConsoleApp.csproj
```
Step4: Add a Project Reference:
Add a reference to the library project from the console application project:
```
dotnet add MyConsoleApp/MyConsoleApp.csproj reference MyLibrary/MyLibrary.csproj
```

Step 5: Build and Run the Projects

Restore Dependencies and Build the Solution:
Run the following commands to restore dependencies and build the solution:
```
dotnet restore
dotnet build
```

Step 6: Run the Console Application:
Run the console application with a command-line argument:

```
dotnet run --project MyConsoleApp/MyConsoleApp.csproj John
```

You should see the output:
```
Hello, John!
```