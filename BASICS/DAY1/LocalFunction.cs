using System;


namespace DAY1
{
    
    internal class LocalFunction
    {
        
        static byte ByteData = 0;
        public void OuterFunction()
        {
            int i = 10;

            Console.WriteLine("accessing outer variable in outer function only value is: "+i);

        void InnerFunction()
        {
                i++;
            Console.WriteLine("accessing outer variable in inner function  after changing value is :" + i);
        }


            Console.WriteLine("calling inner function");
            InnerFunction();
        
        }

        /*===================================================================================================================*/
        /* We can access outer variable inside the local function but we can't access the variable of local function in outer scope
         * The access specifier of the local variable by default (implicitly) : private
         * So they cannot be accessed outside the class 
         * implicitly mean we cannot give any explicit access specifiers
         * it can only be called from outer function
         */
        /*===================================================================================================================*/

        // Trying to access local function from outside the Outer function

            // InnerFunction(); --->> this is giving error because local function can only be called from inside the containing outer function
        

        public void SecondOuterFunction()
        {
            string str = "second outer function string";

            /* also here static string cannot be defined as in c# static variables are defined  at class level only */

            // static string StaticString = "this is outer function static string";

            //code:

            //static void StaticInnerFunction()
            //{
            //    // Trying to access localvariable of outerfunction ---> error : because static function can only access static variables
            //    Console.WriteLine("accessing string defined in secondouterfunction by its static local function, string :"+ str);
            //}

            /*=====================================================================================================================*/
            /*We can access the non static variable defined in outer function by passing it as a parameter to the local function
             * otherwise the static local function can only access the static data members defined at  class level
             */
            /*=====================================================================================================================*/

            static void StaticInnerFunction(string str)
            {
                // Trying to access localvariable of outerfunction ---> is accessible because essentially it is creating a new localvariable inside the local function
                // StaticInnerFunction(string str) ---> string str = str;
                Console.WriteLine("accessing string defined in secondouterfunction by its static local function, string :" + str);
            }
            StaticInnerFunction(str);
        }

        public static void StaticOuterFunction()
        {
            void InnerFunctionOne(byte ByteData)
            {
                Console.WriteLine("accesing the static data inside innerfunction "+ ByteData);
            }

            static void SInnerFunction(byte ByteData)
            {
                Console.WriteLine("accesing the static data inside static innerfunction " + ByteData);
            }

            InnerFunctionOne(ByteData);
            SInnerFunction(ByteData);
        }
    }
}
