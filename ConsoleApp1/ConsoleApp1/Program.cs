using EmpApp;
using System.Xml.Linq;

namespace EmpApp
{
    public class Employee
    {
        public float GetNetSalary()
        {

            float netSal;
            float incentive = 5000;
            netSal = Basic + incentive;

            return netSal;



        }


        private string name;
        private int empno;
        private float basic;
        private short deptNo;




        public string Name
        {
            get { return name; }
            set
            {
                if (name != value.Trim())
                {
                    name = value;
                }
                else { Console.WriteLine("Invalid Name"); }
            }

        }
        public int Empno
        {
            get { return empno; }

            set {
                if (value > 0) {

                    empno = value;

                }
                else { Console.WriteLine("EmpNo invalid"); }
            } 

        }
        
        
        public float Basic
        {
            get { return basic; }

            set { if (value > 20000 && value < 50000) {

                    basic = value;
                } else { Console.WriteLine("Salary invalid"); }
            }
        
        }
        public short DeptNo {

            get { return deptNo; }

            set { if (value > 0) {

                    deptNo = value;   
                } 
            }
        
        
        }

    }
}

namespace EmpTest {

    class EmpTest {

        static void Main(string[] args)
        {
            

            EmpApp.Employee emp1 = new EmpApp.Employee();
            emp1.Name = "nakul";
            emp1.Empno = 12;
            emp1.Basic = 25000;
            emp1.DeptNo = 11;
            
            Console.WriteLine(emp1.GetNetSalary());
            Console.WriteLine(emp1.Empno);
            Console.WriteLine("Hello, Nakul Ashwin");

        }
    }

}
