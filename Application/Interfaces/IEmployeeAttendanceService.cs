﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeAttendanceService
    {
        void MarkAttendance(EmployeeAttendance attendance);
        //void AddAttendance(EmployeeAttendance attendance);
        IEnumerable<EmployeeAttendance> GetAttendanceByEmployeeId(int employeeId);
    }
}
