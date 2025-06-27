using System.ComponentModel;

namespace DAY2._1ConstructorsAndDestructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class1 class2 = new Class1(100);
            Class1 class3 = new Class1(200, 300);
        }
    }
    public class Class1
    {

        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
        public int Prop3 { get; set; }
        
        private int prop4;
        public int Prop4
        {
            get { return prop4; }
            set
            {
                if(value <100)
                    prop4 = value;
                else
                    Console.WriteLine("invalid Prop4");
            }
        }

        //No Args Constructer 
        public Class1()
        {
            Prop1 = 10;
            Prop2 = 20;
            Prop3 = 30;
            Prop4 = 40;

            Console.WriteLine("No args constructor called");
        }

        /*Constructor with arguments*/
        /*        
        public Class1(int Prop1, int Prop2, int Prop3, int Prop4)
        {
            this.Prop1 = Prop1;
            this.Prop2 = Prop2; 
            this.Prop3 = Prop3; 
            this.Prop4 = Prop4; 
        }
        */

        /* Constructor with arguements and default values */
        /*===================================================*/
        public Class1(int Prop1 = 10, int Prop2 = 20, int Prop3 = 30 , int Prop4 = 40)
        {
            this.Prop1 = Prop1;
            this.Prop2 = Prop2;
            this.Prop3 = Prop3;
            this.Prop4 = Prop4;

            Console.WriteLine("Ctor with params and default values called");
        }

        /*Destructor --> used for cleanup of costly resources like fileioconnection dbConnection*/
        /*========================================================================================*/
        ~Class1()
        {
            Console.WriteLine("destructor called");
        }
    }
}
