using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THSDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {


        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-KOJ8LUF",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@123"
        }; 
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("connection opened");

            string query = "select * from Tbl_Blog";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("conncetion closed"); 

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogId" + dr["BlogId"]);
                Console.WriteLine("BlogTitle" + dr["BlogTitle"]);
                Console.WriteLine("BlogAuthor" + dr["BlogAuthor"]);
                Console.WriteLine("BlogContent" + dr["BlogContent"]);
                Console.WriteLine("_________________________________");


            }
           

        }

        public void Create(string title,string author,string content)
        {

            SqlConnection connection =  new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@blogTitle,@blogAuthor,@blogTitle)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue( "@blogTitle",title);
            cmd.Parameters.AddWithValue( "@blogAuthor",author);
            cmd.Parameters.AddWithValue( "@blogContent",content);
            int result =   cmd.ExecuteNonQuery();
                connection.Close();

            string message = result > 0 ? "saving successful" : "saving failed";
            Console.WriteLine(message);
        }
    }
}
