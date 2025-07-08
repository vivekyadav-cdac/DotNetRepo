namespace DataBase
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ConnectionCheck.Connect();
            //Employee employee = new Employee { EmpNo = 9,Name = "Maruti",Basic = 120000.0m,DeptNo = 10};
            //await AsyncConnection.AsyncCommand(employee);

            //await AsyncDataConnectionWithNonWaitingCode.AsyncSelectReader("select * from Employees");
            //Console.ReadLine();

            DataTableDataSet.CrudUsingDataSet();
        }
    }

    public class Employee
    {
        public int EmpNo {  get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public Employee() { }

        public Employee(int empNo, string name, decimal basic, int deptNo)
        {
            EmpNo = empNo;
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
        }

        public override string? ToString()
        {
            return "["+" EmpNo :"+EmpNo+" Name :"+Name+" Basic :"+Basic+" DeptNo :"+DeptNo+"]";

        }

    }
}
