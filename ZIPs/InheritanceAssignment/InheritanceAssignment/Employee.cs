using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignment
{
    abstract class Employee
    {
        private string? name;// variable
        public string Name //property
        {
            set
            {
                if (value.Length == 0 || value == null)
                {
                    Console.WriteLine("Name should not be null!!");
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        private short deptNo;
        public short DeptNo
        {
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("value must be greater than 0");
                }
                else
                {
                    deptNo = value;
                }
            }
            get
            {
                return deptNo;
            }
        }
        public int EmpNo { get; }// auto property

        public static int empnoCounter = 1;

        public abstract decimal Basic { get; set; }

        public Employee()
        {

        }
        public Employee(string? name, short deptNo)
        {
            Name = name;
            this.EmpNo = empnoCounter++;
            DeptNo = deptNo;
        }

        public abstract decimal CalcNetSalary();
    }
}
