using Application.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly IEmployeeAttendanceRepository _attendanceRepository;

        public EmployeeAttendanceService(IEmployeeAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        //public void AddAttendance(EmployeeAttendance attendance)
        //{
        //    _attendanceRepository.Add(attendance);
        //}

        public void MarkAttendance(EmployeeAttendance attendance)
        {
            _attendanceRepository.Add(attendance);
        }

        public IEnumerable<EmployeeAttendance> GetAttendanceByEmployeeId(int employeeId)
        {
            return _attendanceRepository.GetByEmployeeId(employeeId);
        }
    }
}
