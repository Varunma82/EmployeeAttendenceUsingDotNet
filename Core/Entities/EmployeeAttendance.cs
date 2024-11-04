using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EmployeeAttendance
    {
        public int EmployeeId { get; set; }
        public DateTime Attendance_Date { get; set; }
        public string Status { get; set; }
    }
}
