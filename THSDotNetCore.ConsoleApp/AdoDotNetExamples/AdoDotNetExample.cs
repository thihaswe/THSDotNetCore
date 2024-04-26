using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THSDotNetCore.ConsoleApp.AdoDotNetExamples
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
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("connection opened");

            string query = "select * from Tbl_Blog where BlogID = @blogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("conncetion closed");

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("no data found");
                return;
            }
            DataRow dr = dt.Rows[0];

            Console.WriteLine("BlogId" + dr["BlogId"]);
            Console.WriteLine("BlogTitle" + dr["BlogTitle"]);
            Console.WriteLine("BlogAuthor" + dr["BlogAuthor"]);
            Console.WriteLine("BlogContent" + dr["BlogContent"]);
            Console.WriteLine("_________________________________");

        }
        public void Create(string title, string author, string content)
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@blogTitle,@blogAuthor,@blogTitle)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogTitle", title);
            cmd.Parameters.AddWithValue("@blogAuthor", author);
            cmd.Parameters.AddWithValue("@blogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "saving successful" : "saving failed";
            Console.WriteLine(message);
        }

        public void Update(int blogId, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"
UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] =@blogTitle,
      [BlogAuthor] =@blogAuthor,
      [BlogContent] = @blogContent
 WHERE BlogId = @blogId
";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("blogId", blogId);
            command.Parameters.AddWithValue("blogTitle", title);
            command.Parameters.AddWithValue("blogAuthor", author);
            command.Parameters.AddWithValue("blogContent", content);
            int result = command.ExecuteNonQuery();
            connection.Close();


            string message = result > 0 ? "update successful" : "update falied";
            Console.WriteLine(message);


        }

        public void Delete(int blogId)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @blogId";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@blogId", blogId);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "delete successful" : "delete failed";
            Console.WriteLine(message);


        }
    }

}
