using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using THSDotNetCore.RestApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace THSDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            //string query = "select * from tbl_blog where blogid = @BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();

            var item = FindById(id);
            if (item is null)
            {
                Console.Write("no data found");
                return NotFound("no data found");
            }
           
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            string query = @"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@blogTitle,@blogAuthor,@blogTitle)";

            int result = db.Execute(query, blog);
            string message = result > 0 ? "saving successful" : "saving failed";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {

            var item = FindById(id);
            if (item is null)
            {
                return NotFound("no data found");
            }
            blog.BlogId = id; 
            string query = @"
                    UPDATE [dbo].[Tbl_Blog]
                       SET [BlogTitle] =@blogTitle,
                          [BlogAuthor] =@blogAuthor,
                          [BlogContent] = @blogContent
                     WHERE BlogId = @blogId
                    ";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
           


            int result = db.Execute(query, blog);
            string message = result > 0 ? "update successful" : "update failed";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("no data found");
            }
            string conditions = string.Empty;
            if (string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if(conditions.Length == 0)
            {
                return NotFound("no data to update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogId = id;
            string query = $@"
                    UPDATE [dbo].[Tbl_Blog]
                       SET {conditions}
                     WHERE BlogId = @blogId
                    ";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "update successful" : "update failed";
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {

            var item = FindById(id);
            if (item is null)
            {
                return NotFound("no data found");
            }
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @blogId";
         
            int result = db.Execute(query, new BlogModel { BlogId = id} );
            string message = result > 0 ? "delete successful" : "delete failed";
            return Ok(message);

        }

        private BlogModel FindById(int id)
        {
            string query = "select * from tbl_blog where blogid = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }
}
