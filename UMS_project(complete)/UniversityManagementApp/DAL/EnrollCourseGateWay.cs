using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DAL
{
    public class EnrollCourseGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;

        public List<EnrollCourseViewModel> GetAllStudent()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select S.Id, S.Name, S.Email, S.DepartmenteId, S.RegistrationNo, D.Name AS DepartmentName From Student AS S INNER JOIN Department AS D ON S.DepartmenteId = D.Id";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<EnrollCourseViewModel> StudentList = new List<EnrollCourseViewModel>();

            while (reader.Read())
            {
                EnrollCourseViewModel students = new EnrollCourseViewModel();

                students.StudentId = Convert.ToInt32(reader["Id"].ToString());
                students.Name = reader["Name"].ToString();
                students.Email = reader["Email"].ToString();
                students.DepartmentId = Convert.ToInt32(reader["DepartmenteId"].ToString());
                students.RegistrationNo = reader["RegistrationNo"].ToString();
                students.DepartmentName = reader["DepartmentName"].ToString();

                StudentList.Add(students);
            }
            reader.Close();
            connection.Close();

            return StudentList;
        }

        public bool UnassignAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from EnrollStudent where Status='" + 1 + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<EnrollCourseViewModel> courseList = new List<EnrollCourseViewModel>();

            while (reader.Read())
            {
                EnrollCourseViewModel courses = new EnrollCourseViewModel();

                courses.Id = Convert.ToInt32(reader["Id"].ToString());
                courses.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                courses.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                courses.Date = Convert.ToDateTime(reader["EnrollmentDate"].ToString());
                courses.Status = Convert.ToInt32(reader["Status"].ToString());
                courseList.Add(courses);
            }
            reader.Close();
            connection.Close();

            if(courseList.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var course in courseList)
                {

                    string query1 = "UPDATE EnrollStudent SET Status='" + 0 +" '";

                    SqlCommand command1 = new SqlCommand(query1, connection);
                    connection.Open();
                    int rowAffected = command1.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
        }

        public bool saveEnroll(int studentId, int courseId, DateTime Date)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select StudentId, CourseId from EnrollStudent where StudentId='" + studentId + "' AND CourseId='" + courseId + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsEnrollExits = reader.HasRows;
            connection.Close();

            if (IsEnrollExits)
            {
                return false;
            }
            else
            {
                string query2 = "INSERT INTO EnrollStudent(StudentId, CourseId, EnrollmentDate, Status) VALUES('" + studentId + "','" + courseId + "', '" + Date + "', '"+ 1 +"')";

                SqlCommand command2 = new SqlCommand(query2, connection);
                connection.Open();
                int rowAffected = command2.ExecuteNonQuery();
                connection.Close();

                if(rowAffected > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Course> GetStudentCourses(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select Id, Name From Course Where DepartementId = '" + departmentId + "' ";
            
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                Course courses = new Course();

                courses.Id = Convert.ToInt32(reader["Id"].ToString());
                courses.Name = reader["Name"].ToString();
                courseList.Add(courses);
            }
            reader.Close();
            connection.Close();

            return courseList;
        }
    }
}