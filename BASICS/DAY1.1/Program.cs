namespace DAY1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Properties properties = new Properties();

            properties.Prop1 = 1;

            Console.WriteLine("accessing the field uing Property "+ properties.Prop1);
        }
    }
}
