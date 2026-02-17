mkdir MethodsDemo
cd MethodsDemo/
dotnet new solution --name demo
dotnet new console --name ConsoleApp
dotnet sln add ConsoleApp/ConsoleApp.csproj
dotnet new classlib -n Utilities --framework net8.0
dotnet sln add Utilities/Utilities.csproj