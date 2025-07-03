using InheritanceExample;

namespace DAY2._3AccessSpecifiersInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DerivedClass3 derivedClass3 = new DerivedClass3();
        }
    }

    public class BaseClass
    {
        public int A { get; set; }
        public int B { get; set; }

        public BaseClass(int A, int B)
        {
            this.A = A;
            this.B = B;
        } 
    }

    public class DerivedClass : BaseClass
    {
        public int C { get; set; }

        public int D { get; set; }

        private int E { get; set; }

        public DerivedClass(int A, int B, int C, int D, int E) : base(A, B)
        {
            this.C = C;
            this.D = D;
            this.E = E;
        }
    }

    public class DerivedClass2: DerivedClass
    {
        public DerivedClass2(int A, int B, int C, int D, int E) :base(A, B, C, D, E)
        {
            Console.WriteLine("this is derivedclass2 paramctor");
        }
    }
}
namespace InheritanceExample
{
    public class Class2
    {
        public int A { get; set; }

        public int B { get; set; }

        private int Private {  get; set; }

        protected int Protected {  get; set; }

        internal int Internal {  get; set; }

        protected internal int Protected_Internal {  get; set; }

        private protected int Private_Protected {  get; set; }

        public Class2() { }
        public Class2(int A, int B, int Private, int Protected, int Internal, int Protected_Internal, int Private_Protected)
        {
            this.A = A;
            this.B = B;
            this.Private = Private;
            this.Protected = Protected;
            this.Internal = Internal;
            this.Protected_Internal = Protected_Internal;
            this.Private_Protected = Private_Protected;
        }
    }

    public class DerivedClass3 : Class2
    {

        public DerivedClass3() { }
        public DerivedClass3(int A, int B, int Private, int Protected, int Internal, int Protected_Internal, int Private_Protected) : base(A, B, Private, Protected, Internal, Protected_Internal, Private_Protected)
        {

        }
    }
}
