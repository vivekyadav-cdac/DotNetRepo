namespace TasksBasic
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Task t1 = new Task(new Action(Func1));
            Task t2 = new Task(Func2);
            
            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();

           
        }
        
        static void Main2(string[] args)
        {
            Task t1 = Task.Factory.StartNew(Func1);
            Task t2 = Task.Factory.StartNew(Func2);
            Task t3 = Task.Factory.StartNew(new Action<object>(Func3),"passed value");
            Task t4 = Task.Factory.StartNew(new Action<object>(Func4), "passed value  in func4");
            t1.Wait();
            t2.Wait();
            t3.Wait();
            t4.Wait();
        }

        static void Main()
        {
            Task t1 = Task.Run(Func1);
            Task t2 = Task.Run(Func2);
            Task t3 = Task.Run(new Func<int>(Func5));
            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("first :"+i);
            }
        }

        static void Func2()
        {
            for(int i = 0;i < 10; i++)
            {
                Console.WriteLine("second :"+i);
            }
        }

        static void Func3(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("third :"+i+o.ToString);
            }
        }

        static void Func4(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("fourth :"+i+o.ToString);
            }
        }

        static int Func5()
        {
            return 10;

        }
    }
}
