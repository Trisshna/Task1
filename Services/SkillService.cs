using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SkillService : ISkill
    {
        private readonly TaskEmpContext _taskEmpContext;
        public SkillService(TaskEmpContext taskEmpContext)
        {
            _taskEmpContext = taskEmpContext;
        }
        public async Task<IEnumerable<SkillResponse>> GetAllSkills()
        {
            var result = await _taskEmpContext.Skills.Include(x => x.skillmap).ThenInclude(x => x.skills).Select(x => new SkillResponse
            {
                SkillID = x.SkillID,
                Name = x.Name,
                employee = x.skillmap.Select(y => y.employee.EmpName).ToList()
            }).ToListAsync();
            return result;
        }
    }
}