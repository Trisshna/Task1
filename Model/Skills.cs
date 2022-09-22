using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Skills
    {
        [Key]
        public int SkillID { get; set; }
        public string Name { get; set; }
        public ICollection<SkillMap> skillmap { get; set; }
    }
    public class Skillswithemployees
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public List<string> Employees { get; set; }

    }
}
