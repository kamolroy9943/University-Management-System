using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DAL
{
    public class ResultGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;
        public List<Course> GetEnrollCourses(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select ES.CourseId, C.Name AS CourseName from EnrollStudent AS ES INNER JOIN Course AS C ON ES.CourseId = C.Id Where ES.StudentId = '"+ studentId + "'";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                Course courses = new Course();

                courses.Id = Convert.ToInt32(reader["CourseId"].ToString());
                courses.Name = reader["CourseName"].ToString();
                courseList.Add(courses);
            }
            reader.Close();
            connection.Close();

            return courseList;
        }

        public List<Result> loadResultInfo(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "select C.Code, C.Name, SG.Grade from Student AS S FULL OUTER JOIN StudentGrade AS SG ON S.Id = SG.StudentId FULL OUTER JOIN Course AS C ON SG.CourseId = C.Id Where S.Id = '"+ studentId +"'";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Result> resultViewList = new List<Result>();

            while (reader.Read())
            {
                Result results = new Result();

                results.Code = reader["Code"].ToString();
                results.Name = reader["Name"].ToString();
                results.Grade = reader["Grade"].ToString();

                resultViewList.Add(results);
            }
            reader.Close();
            connection.Close();

            return resultViewList;
        }

        public bool saveResult(Result result)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select StudentId, CourseId from StudentGrade where StudentId='" + result.StudentId + "' AND CourseId='" + result.CourseId + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsResultExits = reader.HasRows;
            connection.Close();

            if (IsResultExits)
            {
                return false;
            }
            else
            {
                string query2 = "INSERT INTO StudentGrade(StudentId, CourseId, Grade) VALUES('" + result.StudentId + "','" + result.CourseId + "', '" + result.Grade + "')";

                SqlCommand command2 = new SqlCommand(query2, connection);
                connection.Open();
                int rowAffected = command2.ExecuteNonQuery();
                connection.Close();
                if (rowAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}