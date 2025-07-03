namespace Collections
{
    class Tester
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Add employees(y/n)?");

            string choice = Console.ReadLine()!;

            while (choice.Equals("y"))
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter empno");
                employee.EmpNo = Convert.ToInt32(Console.ReadLine()!);

                Console.WriteLine("Enter name");
                employee.Name = Console.ReadLine()!;

                employees.Add(employee);

                Console.WriteLine("Add employees(y/n)?");
                choice = Console.ReadLine()!;
            }

            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp);
            }
            Employee[] employeeArray = employees.ToArray();
            Console.WriteLine($"Array -[{employeeArray[0]}]");
            List<Employee> employeeList = employeeArray.ToList();
            Console.WriteLine(employeeList[0]);
        }
    }

    class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {
            return EmpNo + ", " + Name;
        }
    }
}