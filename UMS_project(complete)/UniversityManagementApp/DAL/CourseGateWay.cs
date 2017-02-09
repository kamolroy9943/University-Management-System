using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace UniversityManagementApp.DAL
{
    public class CourseGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;
        public List<Semester> GetAllSemester()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select * from Semester ORDER BY Name";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Semester> semesterList = new List<Semester>();

            while (reader.Read())
            {
                Semester semesters = new Semester();
                semesters.Id = Convert.ToInt32(reader["Id"].ToString());
                semesters.Name = reader["Name"].ToString();

                semesterList.Add(semesters);
            }
            reader.Close();
            connection.Close();

            return semesterList;
        }

   
        public List<CourseStaticsViewModel> loadCourseInfo(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select C.Code, C.Name, S.Name AS SemesterName, T.Name AS TeacherName from Course AS C FULL OUTER JOIN TeacherAssign AS TA ON C.Id = TA.CourseId FULL OUTER JOIN Teacher AS T ON TA.TeacherId = T.Id FULL OUTER JOIN Semester AS S ON C.SemisterId = S.Id Where C.DepartementId = '" + departmentId +"' ";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<CourseStaticsViewModel> courseStaticsViewList = new List<CourseStaticsViewModel>();

            while (reader.Read())
            {
                CourseStaticsViewModel coursesStatics = new CourseStaticsViewModel();
                
                coursesStatics.Code = reader["Code"].ToString();
                coursesStatics.Name = reader["Name"].ToString();
                coursesStatics.Semester = reader["SemesterName"].ToString();
                coursesStatics.AssignedTo = reader["TeacherName"].ToString();

                courseStaticsViewList.Add(coursesStatics);
            }
            reader.Close();
            connection.Close();

            return courseStaticsViewList;
        }

        public bool IsCourseAssign(int courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From TeacherAssign WHERE CourseId = '" + courseId + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsCourseAssign = reader.HasRows;
            connection.Close();

            return IsCourseAssign;
        }

        public List<Course> GetCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select * from Course ORDER BY Name";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                Course courses = new Course();
                courses.Id = Convert.ToInt32(reader["Id"].ToString());
                courses.Name = reader["Name"].ToString();
                courses.Code = reader["Code"].ToString();
                courses.DepartmentId = Convert.ToInt32(reader["DepartementId"].ToString());
                courses.Credit = Convert.ToInt32(reader["Credit"].ToString());

                courseList.Add(courses);
            }
            reader.Close();
            connection.Close();

            return courseList;
        }

        public List<CourseViewModel> GetCourseView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "select c.Code AS CourseCode,  C.Name AS CourseName, C.Credit AS CourseCredit, C.Description, D.Name AS DepartmentName, S.Name AS SemesterName FROM Course AS C Inner Join Department AS D On C.DepartementId = D.Id Inner Join Semester AS S On C.SemisterId = S.Id";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<CourseViewModel> courseViewList = new List<CourseViewModel>();

            while (reader.Read())
            {
                CourseViewModel courseViews = new CourseViewModel();
                courseViews.Code = reader["CourseCode"].ToString();
                courseViews.Name = reader["CourseName"].ToString();
                courseViews.Credit = reader["CourseCredit"].ToString();
                courseViews.Description = reader["Description"].ToString();
                courseViews.Department = reader["DepartmentName"].ToString();
                courseViews.Semester = reader["SemesterName"].ToString();

                courseViewList.Add(courseViews);
            }
            reader.Close();
            connection.Close();

            return courseViewList;
        }

        public int SaveCourse(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Course(Code, Name, Credit, Description, DepartementId, SemisterId) VALUES('" + course.Code + "','" + course.Name + "', '"+course.Credit + "', '" + course.Description + "', '" + course.DepartmentId + "', '" + course.SemesterId + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsUniqueValue(string table, string column, string value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select "+ column +" from "+ table + " where " + column + " ='" + value + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsUniqueValue = reader.HasRows;
            connection.Close();

            return IsUniqueValue;
        }
    }
}