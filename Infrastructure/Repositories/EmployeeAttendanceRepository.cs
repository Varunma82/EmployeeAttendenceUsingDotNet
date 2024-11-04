using Core.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class EmployeeAttendanceRepository : IEmployeeAttendanceRepository
    {
        private readonly string _connectionString;

        public EmployeeAttendanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(EmployeeAttendance attendance)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("CreateAttendance", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@EmployeeId", attendance.EmployeeId);
                command.Parameters.AddWithValue("@Attendance_Date", attendance.Attendance_Date);
                command.Parameters.AddWithValue("@Status", attendance.Status);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<EmployeeAttendance> GetByEmployeeId(int employeeId)
        {
            var attendanceRecords = new List<EmployeeAttendance>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetAttendanceByEmployeeId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var attendance = new EmployeeAttendance
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        Attendance_Date = (DateTime)reader["Attendance_Date"],
                        Status = (string)reader["Status"]
                    };
                    attendanceRecords.Add(attendance);
                }
            }

            return attendanceRecords;
        }
    public void UpdateAttendance(EmployeeAttendance attendance)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("UpdateAttendance", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AttendanceId", attendance.EmployeeId);
            command.Parameters.AddWithValue("@Attendance_Date", attendance.Attendance_Date);
            command.Parameters.AddWithValue("@Status", attendance.Status);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAttendance(int attendanceId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("DeleteAttendance", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AttendanceId", attendanceId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}