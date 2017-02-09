using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DAL
{
    public class StudentGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;
        public List<Student> GetAllStudent()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "SELECT * FROM Student ORDER BY Name";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Student> studentList = new List<Student>();

            while (reader.Read())
            {
                Student students = new Student();
                students.Id = Convert.ToInt32(reader["Id"].ToString());
                students.Name = reader["Name"].ToString();
                students.Address = reader["Address"].ToString();
                students.Email = reader["Email"].ToString();
                students.ContactNo = reader["ContactNo"].ToString();
                students.Date = Convert.ToDateTime(reader["Date"]); 
                students.DepartmentId = Convert.ToInt32(reader["DepartmenteId"].ToString());
                students.RegistrationNo = reader["RegistrationNo"].ToString();

                studentList.Add(students);
            }
            reader.Close();
            connection.Close();

            return studentList;
        }

        public int SaveStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Student(Name, Email, ContactNo, Date, Address, DepartmenteId, RegistrationNo) VALUES('" + student.Name + "','" + student.Email + "', '" + student.ContactNo + "', '" + student.Date + "', '" + student.Address + "', '" + student.DepartmentId + "', '" + student.RegistrationNo + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}