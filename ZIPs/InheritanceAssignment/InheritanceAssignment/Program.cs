namespace InheritanceAssignment
{
    class Tester
    {

        public static void Main(String[] args)
        {
            Employee manager = new Manager("Nikunj", 1, "Manager", 10000);
            Console.WriteLine(manager);


            Employee generalManager = new GeneralManager("Raghav Gangrape", 2, "General Manager", 100, "perks");

            Console.WriteLine(generalManager);
        }
    }
}