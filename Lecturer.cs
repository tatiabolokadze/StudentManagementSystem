using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp69
{
    public class Lecturer
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public Lecturer(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public void GiveFeedback(Student student, string feedbackText)
        {
            Feedback feedback = new Feedback(student.Id, this.Name, feedbackText);
            student.AddFeedback(feedback);
            Console.WriteLine("Feedback added successfully.");
        }
    }
}
