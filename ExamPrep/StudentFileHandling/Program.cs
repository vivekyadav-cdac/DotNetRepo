using System.Text.Json;

namespace StudentFileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            //    Console.WriteLine("Enter number of students to be entered");
            //    int num = int.Parse(Console.ReadLine());

            //    for(int i = 0; i < num; i++)
            //    {
            //        Console.WriteLine("Enter the roll No of student");
            //        int RollNo = int.Parse(Console.ReadLine()); 

            //        Console.WriteLine("Enter the name of student");
            //        string Name = Console.ReadLine();

            //        Console.WriteLine("Enter the subject name");
            //        string Subject = Console.ReadLine();

            //        Console.WriteLine("Enter the marks ");
            //        decimal Marks = decimal.Parse(Console.ReadLine());

            //        Student student = new Student(RollNo,Name,Subject,Marks);
            //        students.Add(student);
            //    }

            //    string FilePath = "students.txt";

            //    using(StreamWriter sw = new StreamWriter(FilePath))
            //    {
            //        foreach(Student student in students)
            //        {
            //            sw.WriteLine(student.ToString());
            //        }
            //    }

            //    Console.WriteLine($"Students data written to file {FilePath}");

            //    Console.WriteLine("Reading from file");

            //    if(File.Exists(FilePath))
            //    {
            //        String[] lines = File.ReadAllLines(FilePath);
            //        foreach(String line in lines)
            //        {
            //            Console.WriteLine(line);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("File not found");
            //    }

            // Serialization using JSON

            Console.Write("Enter number of students to be entered: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\nEnter the roll No of student");
                int rollNo = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the name of student");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the subject name");
                string subject = Console.ReadLine();

                Console.WriteLine("Enter the marks");
                decimal marks = decimal.Parse(Console.ReadLine());

                students.Add(new Student(rollNo, name, subject, marks));
            }

            // Serialize and save
            string filePath = "students.json";
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"\nStudents data written to file {filePath}");

            // Deserialize and display
            Console.WriteLine("Reading from file:");
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                List<Student> studentsFromFile = JsonSerializer.Deserialize<List<Student>>(data);

                foreach (var student in studentsFromFile)
                {
                    Console.WriteLine(student); // Will use ToString()
                }
            }
        }


    }
}
