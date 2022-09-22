using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Emp
    {

        [Key]
        public int employeeID { get; set; }
        public string EmpName { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string WFMmanager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal Experience { get; set; }
        public int ProfileID { get; set; }
        //  public ICollection<Skills> skills { get; set; }
        public ICollection<SkillMap> skillmap { get; set; }
    }

    public class Employeeswithskills
    {
        [Key]
        public int employeeID { get; set; }
        public string EmpName { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string WFMmanager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal Experience { get; set; }
        public int ProfileID { get; set; }
        [NotMapped]
        public List<string> Skills { get; set; }
    }
}