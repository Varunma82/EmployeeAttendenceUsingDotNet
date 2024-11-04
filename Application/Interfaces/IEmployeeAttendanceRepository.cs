using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface IEmployeeAttendanceRepository
    {
        void Add(EmployeeAttendance attendance);
        IEnumerable<EmployeeAttendance> GetByEmployeeId(int employeeId);
        
    }
