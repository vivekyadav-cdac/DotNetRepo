using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignment
{
    class GeneralManager : Manager
    {
        public string Perks { get; set; }
        public GeneralManager(string? name, short deptNo, string? designation, decimal basic, string perks) : base(name, deptNo, designation, basic)
        {
            Perks = perks;
        }

        public override string? ToString()
        {
            return EmpNo + "," + Name + ", " + Designation + ", " + DeptNo + ", " + Basic + ", " + Perks;
        }
    }
}
