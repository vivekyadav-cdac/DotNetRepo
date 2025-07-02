namespace DayTwoAssingment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Amol",1234566,10);
            Employee employee2 = new Employee("Anmol",234156);
            Employee employee3 = new Employee("Anil");
            Employee employee4 = new Employee();

            Console.WriteLine("first object of Employee Number :" + employee.Empno);
            Console.WriteLine("second object of Employee Number :" + employee2.Empno);
            Console.WriteLine("third object of Employee Number :" + employee3.Empno);
            Console.WriteLine("fourth object of Employee Number :" + employee4.Empno);
        }
    }
}
