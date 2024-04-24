using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace THSDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(22);
            //Create("title", "author", "content");
            //Update(1, "superman", "spiderman", "ironman");
            Delete(14);

        }
        
        private void Read() 
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            //            using (IDbConnection db1 = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString)
            //            {            
            //                db1.Open();
            //            } 
        List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();

            foreach (BlogDto item in lst) 
            { 
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("----------------");
        
            }
             
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
           var item =  db.Query<BlogDto>("select * from tbl_blog where blogid = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if(item is null) 
            {
                Console.Write("no data found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("----------------");


        }

        private void Create(string title,string author,string content)
        {

            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content   

            };
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            string query = @"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@blogTitle,@blogAuthor,@blogTitle)";

          int result =   db.Execute(query, item);
            string message = result > 0 ? "saving successful" : "saving failed";
            Console.WriteLine(message);

        }

        private void Update(int id,string title, string author, string content)
        {

            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            string query = @"
                    UPDATE [dbo].[Tbl_Blog]
                       SET [BlogTitle] =@blogTitle,
                          [BlogAuthor] =@blogAuthor,
                          [BlogContent] = @blogContent
                     WHERE BlogId = @blogId
                    ";


            int result = db.Execute(query, item);
            string message = result > 0 ? "update successful" : "update failed";
            Console.WriteLine(message);

        }

        private void Delete(int id) 

        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @blogId";
            var item = new BlogDto
            {
                BlogId = id,
            };

          int result =   db.Execute(query, item);
            string message = result > 0 ? "delete successful" : "delete failed";
            Console.WriteLine(message);

        }
    }



   
   
}
