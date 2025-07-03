namespace DAYOneAssingment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Name = "Vivek";
            employee.Empno = 10;
            employee.Basic = 15000;
            employee.Deptno = 2;


            Console.WriteLine("Net salary of employee is :"+employee.GetNetSalary());
        }
    }

}
