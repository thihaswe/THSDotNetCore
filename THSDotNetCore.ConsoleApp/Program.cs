// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch4.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;
using THSDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");
AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("hello", "hello", "hello");
//adoDotNetExample.Update(1, "title 1", "author 1", "content 1");
//adoDotNetExample.Delete(15 );
//adoDotNetExample.Edit(15);
//adoDotNetExample.Edit(1);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();


Console.ReadKey();



