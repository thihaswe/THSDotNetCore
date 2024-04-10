// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "DESKTOP-KOJ8LUF";
stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";

SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);  
connection.Open();
Console.WriteLine("connection opened");

string query = "select * from Tbl_Blog";
SqlCommand cmd = new SqlCommand(query,connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);


connection.Close();
Console.WriteLine("conncetion closed"); 
foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("BlogId" + dr["BlogId"]);
    Console.WriteLine("BlogTitle" + dr["BlogTitle"]);
    Console.WriteLine("BlogAuthor" + dr["BlogAuthor"]);
    Console.WriteLine("BlogContent" + dr["BlogContent"]);
  

}

Console.ReadKey();


