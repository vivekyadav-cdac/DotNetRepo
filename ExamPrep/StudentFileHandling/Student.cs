using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentFileHandling 
{
    public class Student : ISerializable
    {   
        public int RollNo {  get; set; }    
        public string Name { get; set; }    
       
        public string Subject {  get; set; }

        public decimal Marks {  get; set; }

        public Student() { }
        public Student(int rollNo, string name, string subject, decimal marks)
        {
            RollNo = rollNo;
            Name = name;
            Subject = subject;
            Marks = marks;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"RollNo: {RollNo}, Name: {Name}, Subject: {Subject}, Marks: {Marks}";
        }

    }
}
