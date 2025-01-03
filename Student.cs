using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp69
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public List<Feedback> Feedbacks { get; set; }

        public Student()
        {
            Feedbacks = new List<Feedback>();
        }

        public Student(int id, string name, int age, string course)
        {
            Id = id;
            Name = name;
            Age = age;
            Course = course;
            Feedbacks = new List<Feedback>();
        }

        public void AddFeedback(Feedback feedback)
        {
            Feedbacks.Add(feedback);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Course: {Course}";
        }
    }
}
