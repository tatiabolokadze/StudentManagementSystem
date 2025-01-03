using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp69
{
    public class Feedback
    {
        public int StudentId { get; set; }
        public string LecturerName { get; set; }
        public string FeedbackText { get; set; }
        public DateTime Date { get; set; }


        public Feedback()
        {
            StudentId = 0;
            LecturerName = string.Empty;
            FeedbackText = string.Empty;
            Date = DateTime.Now;
        }

        public Feedback(int studentId, string lecturerName, string feedbackText)
        {
            StudentId = studentId;
            LecturerName = lecturerName;
            FeedbackText = feedbackText;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Lecturer: {LecturerName}\nFeedback: {FeedbackText}\nDate: {Date.ToShortDateString()}";
        }
    }
}
