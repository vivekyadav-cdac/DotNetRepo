using System.Linq.Expressions;

namespace CollectionsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            bool flag = true;
            do
            {
                Console.WriteLine("1.Create a new Empployee");
                Console.WriteLine("2.Display Employee with highest salary");
                Console.WriteLine("3.Search Employee by empNum");
                Console.WriteLine("4.Display nth employee");

                Console.WriteLine("Enter your choice");

                int choice = int.Parse(Console.ReadLine());

                switch (choice) 
                {
                
                    case 1:
                        {
                            bool loopFlag = true;
                            while (loopFlag)
                            {
                                Console.WriteLine("Enter Employee Name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter salary");
                                decimal salary = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Enter department");
                                int deptNum = int.Parse(Console.ReadLine());

                                employees.Add(new Employee(name, salary, deptNum));

                                Console.WriteLine("Do you want to add another employee? (Y/N)");

                                string innerChoice = Console.ReadLine();

                                if (innerChoice.ToLower().Equals("n"))
                                {
                                    loopFlag = false;
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            try {
                                if (employees.Count == 0)
                                {
                                    throw new EmployeeException("No employees present in array");
                                }
                                employees.Sort((emp1,emp2)=>emp2.Salary.CompareTo(emp1.Salary));
                                Console.WriteLine(employees.ElementAt(0).ToString);
                            }
                            catch(EmployeeException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("enter employee number to search ");
                            int empNum = int.Parse(Console.ReadLine());

                            try
                            {
                                if(employees.Count == 0)
                                {
                                    throw new EmployeeException("employee list is empty");
                                }
                                if (empNum <= 0 || empNum > employees.Count)
                                {
                                    throw new EmployeeException("enter a valid employee number");
                                }
                                Employee e = null;
                                foreach (Employee emp in employees)
                                {
                                    if (emp.EmpNum == empNum)
                                    {
                                        e = emp;
                                        break;
                                    }
                                }
                                Console.WriteLine(e.ToString());    
                            }
                            catch (EmployeeException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("enter number to search the nth employee ");
                            int num = int.Parse(Console.ReadLine());

                            try
                            {

                                if (employees.Count == 0)
                                {
                                    throw new EmployeeException("employee list is empty");
                                }
                                if (num <= 0 || num > employees.Count)
                                {
                                    throw new EmployeeException("list has no such count number");
                                }
                                Console.WriteLine(employees.ElementAt(num).ToString);
                            }
                            catch (EmployeeException e)
                            {
                                Console.WriteLine(e.Message);
                            }


                        }
                        break;

                }
            }
            while (true);
        }
    }

    public class Employee
    {
        private static int EMPNO_COUNTER = 1;
        private int empNum;
        private string empName;
        private decimal salary;
        private int deptNum;

        public int EmpNum
        {
            get {  return empNum; }
        }

        public string EmpName
        {
            set
            {
                if(value != null)
                {
                    empName = value;    
                }
                else
                {
                    throw new EmployeeException("name cannot be null");
                }
            }
            get {  return empName; }
        }

        public decimal Salary
        {
            set
            { if (value > 100000)
                {
                    salary = value;
                }
                else
                {
                    throw new EmployeeException("salary should be greater than 100000");
                }
            }
            get { return salary; }
        }
        public int DeptNum
        {
            set
            {
                if (value > 0)
                {
                    deptNum = value;
                }
                else
                {
                    throw new EmployeeException("department number cannot be less than 1");
                }
            }
            get { return deptNum; }
        }

        public Employee()
        {
            empNum = EMPNO_COUNTER++;
        }

        public Employee(string EmpName, decimal Salary, int DeptNum)
        {
            this.EmpName = EmpName;
            this.Salary = Salary;  
            this.DeptNum = DeptNum;
        }

        public override string ToString()
        {
            return "[" + "EmpNum :" + EmpNum + "EmpName :" + EmpName + "Salary :" + Salary + "DeptNum :" + DeptNum + "]";
        }
    }
}
