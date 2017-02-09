using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementApp.Models;
namespace UniversityManagementApp.DAL
{
    public class TeacherGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;

        public List<Designation> GetAllDesignation()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select * from Designation ORDER BY Name";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Designation> designationList = new List<Designation>();

            while (reader.Read())
            {
                Designation Designation1 = new Designation();
                Designation1.DesignationId= Convert.ToInt32(reader["Id"].ToString());
                Designation1.DesignationName = reader["Name"].ToString();


                designationList.Add(Designation1);
            }
            reader.Close();
            connection.Close();

            return designationList;
        }

        public List<Teacher> GetTeacher()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "select * FROM Teacher ORDER BY Name";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Teacher> teacherList = new List<Teacher>();

            while (reader.Read())
            {
                Teacher teachers = new Teacher();

                teachers.TeacherId = Convert.ToInt32(reader["Id"].ToString());
                teachers.Name = reader["Name"].ToString();
                teachers.Address = reader["Address"].ToString();
                teachers.Email = reader["Email"].ToString();
                teachers.ContactNo = reader["ContactNo"].ToString();
                teachers.DesignationId = Convert.ToInt32(reader["DesignationId"].ToString());
                teachers.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                teachers.CreditToBeTaken = Convert.ToInt32(reader["CreditToBeTaken"].ToString());
                teacherList.Add(teachers);
            }
            reader.Close();
            connection.Close();
            return teacherList;
        }

        public int saveAssign(int teacherId, int courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO TeacherAssign(TeacherId, CourseId) VALUES(@teacherId, @courseId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherId", teacherId);
            command.Parameters.AddWithValue("@courseId", courseId);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<TeacherShowAll> GetTeacherCreditInfo(int teacherId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "select SUM(C.Credit) AS TotalCredit, T.CreditToBeTaken from Teacher AS T FULL OUTER JOIN TeacherAssign AS TA ON TA.TeacherId = T.Id FULL OUTER JOIN Course AS C ON C.Id = TA.CourseId Where T.Id = '" + teacherId+ "' Group By T.CreditToBeTaken";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TeacherShowAll> teacherCreditList = new List<TeacherShowAll>();
            
            while (reader.Read())
            {
                TeacherShowAll teachersCrdit = new TeacherShowAll();
                if (reader["TotalCredit"] != DBNull.Value)
                {
                    teachersCrdit.TotalCredit = Convert.ToInt32(reader["TotalCredit"].ToString());
                }
               
                teachersCrdit.CreditToBeTaken = Convert.ToInt32(reader["CreditToBeTaken"].ToString());
                teacherCreditList.Add(teachersCrdit);
            }

            reader.Close();
            connection.Close();
            return teacherCreditList;
        }

        public List<TeacherShowAll> GetAllTeacher()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "select Teacher.Name,Teacher.Email,Teacher.Address,Teacher.CreditToBeTaken,Teacher.ContactNo,Designation.Name AS Designation,Department.Name AS Department from Teacher Join Designation ON Designation.Id = Teacher.DesignationId Join Department ON Department.Id = Teacher.DepartmentId order by Department.Id";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TeacherShowAll> teacherList = new List<TeacherShowAll>();

            while (reader.Read())
            {
                TeacherShowAll teacherShowAll = new TeacherShowAll();
               
                teacherShowAll.Name = reader["Name"].ToString();
                teacherShowAll.Address = reader["Address"].ToString();
                teacherShowAll.Email = reader["Email"].ToString();
                teacherShowAll.ContactNo = reader["ContactNo"].ToString();
                teacherShowAll.DesignationName = reader["Designation"].ToString();
                teacherShowAll.DepartmentName = reader["Department"].ToString();
                teacherShowAll.CreditToBeTaken = Convert.ToInt32(reader["CreditToBeTaken"].ToString());
                teacherList.Add(teacherShowAll);
            }
            reader.Close();
            connection.Close();
            return teacherList;
        }

        public bool IsTeacherEmailExits(string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Email from Teacher where Email ='" + email + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool isTeacherEmailExits = reader.HasRows;
            connection.Close();

            return isTeacherEmailExits;
        }

      public bool IsTeacherContactNoExits(string contactNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select ContactNo from Teacher where ContactNo='" + contactNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool isTeacherContactNoExits = reader.HasRows;
            connection.Close();

            return isTeacherContactNoExits;
        }

        public int SaveTeacher(Teacher teacher)
        {
           
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Teacher(Name,Address,Email,ContactNo,DesignationId,DepartmentId,CreditToBeTaken) VALUES(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditToBeTaken)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", teacher.Name);
            command.Parameters.AddWithValue("@Address", teacher.Address);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@ContactNo", teacher.ContactNo);
            command.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
            command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            command.Parameters.AddWithValue("@CreditToBeTaken", teacher.CreditToBeTaken);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        
    }
}