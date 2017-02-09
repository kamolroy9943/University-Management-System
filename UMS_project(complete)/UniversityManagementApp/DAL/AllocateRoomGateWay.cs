using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementApp.DAL;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace UniversityManagementApp.DAL
{
    public class AllocateRoomGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;

        public List<Room> GetAllRoom()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string quary = "Select * from Room ORDER BY RoomNumber";

            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Room> roomList = new List<Room>();

            while (reader.Read())
            {
                Room rooms = new Room();
                rooms.Id = Convert.ToInt32(reader["Id"].ToString());
                rooms.RoomNumber = reader["RoomNumber"].ToString();

                roomList.Add(rooms);
            }
            reader.Close();
            connection.Close();

            return roomList;
        }

        public bool UnallocateAllRoom()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from AllocateClassRoom where Status='" + 1 + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<AllocateClassRomm> roomList = new List<AllocateClassRomm>();

            while (reader.Read())
            {
                AllocateClassRomm rooms = new AllocateClassRomm();

                rooms.Id = Convert.ToInt32(reader["Id"].ToString());
                //rooms.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                rooms.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                //rooms.Date = Convert.ToDateTime(reader["EnrollmentDate"].ToString());
                rooms.Status = Convert.ToInt32(reader["Status"].ToString());
                roomList.Add(rooms);
            }
            reader.Close();
            connection.Close();

            if (roomList.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var room in roomList)
                {

                    string query1 = "UPDATE AllocateClassRoom SET Status='" + 0 + " '";

                    SqlCommand command1 = new SqlCommand(query1, connection);
                    connection.Open();
                    int rowAffected = command1.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
        }

        public int Save(AllocateClassRomm allocateClassRomm)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO AllocateClassRoom(CourseId, RoomId, Day, FromHour, FromMin, FromDay, ToHour, ToMin, ToDay, Status) VALUES('" + allocateClassRomm.CourseId + "','" + allocateClassRomm.RoomId + "', '" + allocateClassRomm.Day + "', '" + allocateClassRomm.FromHour + "', '" + allocateClassRomm.FromMin + "', '" + allocateClassRomm.FromDay + "', '"+ allocateClassRomm.ToHour+ "', '" + allocateClassRomm.ToMin + "', '" + allocateClassRomm.ToDay + "', '" + 1 + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}