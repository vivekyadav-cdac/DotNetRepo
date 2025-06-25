using DAY1.InnerNameSpace;
using System;
namespace DAY1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Class1 obj = new Class1();
            obj.Display();

            obj.Display("overloaded");
        }

        static void Main2(string[] args)
        {

            Class1 class1 = new Class1();
            
            // here we are passing only two values
            // so for third param default value c=0 is being used
            Console.WriteLine(class1.Add(1,2));

            // here we are passing three values 
            // so all of them are used 
            Console.WriteLine(class1.Add(3,4,5));

            /*==========================================================================================*/
            // functions with default values give same functionality
            // as overloaded functions as long as datatype of params and return type remains same
            /*==========================================================================================*/
        }

        static void Main3(string[] args)
        {
            LocalFunction localFunction = new LocalFunction();

            localFunction.OuterFunction();

            //Trying to access localFunction from LocalFunction class
                //localFunction.InnerFunction() -->> gives error as a local function is implicitly private and not available outside the class

            localFunction.SecondOuterFunction();

            //Trying to access static function from LocalFunction class
            // for this we need to use class name we can't use object to access static function

            //Code:
            //localFunction.StaticOuterFunction();   --> static member 'member' cannot be accessed with an instance reference;
            //only a class name can be used to qualify a static variable.

            LocalFunction.StaticOuterFunction();
        }

        static void Main(string[] args)
        {

            InnerClass innerClass = new InnerClass();

            innerClass.Inner();
        }
    }

    public class Class1
    {
        //public void Display()
        //{
        //    Console.WriteLine("display called");
        //}

        //public void Display(string s)
        //{
        //    Console.WriteLine("display called with :" + s);
        //}

        /*===========================================================*/

        /* whenever we need to overload 
         we should prefer using function with default values instead
         In function default values should be given from right to left
           */

        /*===========================================================*/

        // Funtion with default params
        public void Display(string s = "")
        {
            Console.WriteLine("display called "+s);
        }

        // Function for add with default params

        public int Add(int a = 0, int b = 0, int c = 0)
        {
            return a + b + c;
        }
    }
}
