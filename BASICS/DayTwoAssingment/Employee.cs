using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwoAssingment
{
    public class Employee
    {
        private static int empnoCounter = 1;

        private string name;
        private int empno;
        private decimal basic;
        private short deptno;

        public Employee()
        {
            empno = empnoCounter++;
        }

        public Employee(string Name="", decimal Basic =123456, short Deptno=10)
        {
            empno = empnoCounter++;
            this.Name = Name;
            this.Basic = Basic;
            this.Deptno = Deptno;
        }
        public string Name
        {
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("name is required");
                }
            }
            get { return name; }
        }

        public int Empno
        {
            get { return empno; }
        }

        public decimal Basic
        {
            set
            {
                if (value >= 15000 && value <=1234567 )
                {
                    basic = value;
                }
                else
                {
                    Console.WriteLine("Basic must be between 5000 and 15000");
                }
            }
            get { return basic; }
        }

        public short Deptno
        {
            set
            {
                if (value > 0)
                {
                    deptno = value;
                }
                else
                {
                    Console.WriteLine("Dept no should start with 1");
                }
            }
            get { return deptno; }
        }

        public decimal GetNetSalary()
        {
            decimal HRA = basic * 0.2m;
            decimal DA = basic * 0.1m;
            decimal allowances = 1000m;
            decimal deductions = basic * 0.12m;

            decimal netSalary = basic + HRA + DA + allowances - deductions;

            return netSalary;
        }
    }
}
