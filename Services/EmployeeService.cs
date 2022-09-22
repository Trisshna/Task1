using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EmpService : IEmployee
    {
        private readonly TaskEmpContext _taskEmpContext;


        public EmpService(TaskEmpContext taskEmpContext)
        {
            _taskEmpContext = taskEmpContext;
        }

        public async Task<IEnumerable<Employeeswithskills>> GetEmployees()
        {
            var data = await _taskEmpContext.Employees.Select(x => new Employeeswithskills()
            {
                employeeID = x.employeeID,
                EmpName = x.EmpName
            }).ToListAsync();

            if (data != null)
            {
                return data;
            }
            return new List<Employeeswithskills>();
        }
    }
}
