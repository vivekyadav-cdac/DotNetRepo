using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignment
{
    class Manager : Employee
    {
        private string designation;
        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                if(value != null || value != "")
                {
                    designation = value;
                }
                else
                {
                    Console.WriteLine("Designation cannot be null");
                }
            }
        }
        
        public override decimal Basic { get; set; }

        public override decimal CalcNetSalary()
        {
            return Basic * 90;
        }


        public Manager(string? name, short deptNo, string designation, decimal basic): base(name, deptNo)
        {
            Basic = basic;
            Designation = designation;
        }
        public override string? ToString()
        {
            return EmpNo + "," + Name + ", " + Designation + ", "+ DeptNo + ", " + Basic;
        }
    }
}
