namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DerivedClass derivedClass = new DerivedClass();
            DerivedClass derivedClass1 = new DerivedClass(10,20);
        }
    }

    public class BaseClass
    {
        public int i;

        public BaseClass()
        {
            i = 0;
            Console.WriteLine("Base class no params ctor");
        }

        public BaseClass(int i)
        {
            this.i = i;

            Console.WriteLine("Base class params ctor");
        }

    }

    public class DerivedClass : BaseClass
    {

        public int j;

        public DerivedClass()
        {
            j = 20;
            Console.WriteLine("Derived class no params ctor");
        }

        public DerivedClass(int i, int j): base(i) 
        {
            this.j = j;
            Console.WriteLine("Derived class params ctor");
        }
    
    }

}
