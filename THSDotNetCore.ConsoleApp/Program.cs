// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THSDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");
AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
adoDotNetExample.Create("hello", "hello", "hello");
Console.ReadKey();



