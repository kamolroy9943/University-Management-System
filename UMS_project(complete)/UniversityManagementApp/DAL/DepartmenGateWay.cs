using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DAL
{
    public class DepartmenGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;

        public bool IsCodeExits(string code)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Code from Department where Code='" + code + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsCodeExits = reader.HasRows;
            connection.Close();

            return IsCodeExits;
        }

        public List<Department> GetAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select * from Department ORDER BY Name";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Department> departmentList = new List<Department>();

            while (reader.Read())
            {
                Department departments = new Department();
                departments.Id = Convert.ToInt32(reader["Id"].ToString());
                departments.Name = reader["Name"].ToString();
                departments.Code = reader["Code"].ToString();

                departmentList.Add(departments);
            }
            reader.Close();
            connection.Close();

            return departmentList;
        }

        public int SaveDepartment(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Department(Name,Code) VALUES('" + department.Name + "','" + department.Code + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsNameExists(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Name from Department where Name='" + name + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsNameExists = reader.HasRows;
            connection.Close();

            return IsNameExists;
        }
        
    }
}