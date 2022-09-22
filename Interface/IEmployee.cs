using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IEmployee
    {
        public Task<IEnumerable<Employeeswithskills>> GetEmployees();
    }
}