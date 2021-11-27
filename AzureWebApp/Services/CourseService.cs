using AzureWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebApp.Services
{
    public class CourseService
    {
        // Ensure to change the below variables to reflect the connection details for your database
        //private static string db_source = "test-app.database.windows.net";
        //private static string db_user = "tiwaridiwakar9";
        //private static string db_password = "12@priL1995";
        //private static string db_database = "FirstAzureDB";

        private SqlConnection GetConnection(string connectionString)
        {
            //// Here we are creating the SQL connection
            //var _builder = new SqlConnectionStringBuilder
            //{
            //    DataSource = db_source,
            //    UserID = db_user,
            //    Password = db_password,
            //    InitialCatalog = db_database
            //};
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Course> GetCourses(string connectionString)
        {
            List<Course> _lst = new();
            string _statement = "SELECT CourseID,CourseName,Rating from Course";
            SqlConnection _connection = GetConnection(connectionString);
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }

    }
}
