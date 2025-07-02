using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignment
{
    class CEO : Employee
    {
        public override decimal Basic { get; set; }

        public sealed override decimal CalcNetSalary()
        {
            return Basic * 95;
        }

        public CEO(string? name, short deptNo, decimal basic) : base(name, deptNo)
        {
            Basic = basic;
        }
    }
}
