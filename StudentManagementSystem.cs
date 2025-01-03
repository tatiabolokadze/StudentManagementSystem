using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp69
{
    public class StudentManagementSystem
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/StudentManagementSystem.xml";
        public List<Student> students;

        public StudentManagementSystem()
        {
            students = LoadStudents();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            SaveStudents();
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void UpdateStudent(Student updatedStudent)
        {
            var student = students.Find(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Course = updatedStudent.Course;
                SaveStudents();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                SaveStudents();
            }
        }

        public List<Student> LoadStudents()
        {
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                return new List<Student>();
            }

            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
                    return (List<Student>)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading students: " + ex.Message);
                return new List<Student>();
            }
        }


        public void SaveStudents()
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Student>));
                serializer.Serialize(stream, students);
            }
        }

        public void ViewStudentSummary()
        {
            Console.WriteLine($"Total Students: {students.Count}");
            var courseCounts = students.GroupBy(s => s.Course)
                .Select(g => new { Course = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);

            Console.WriteLine("Course Summary:");
            foreach (var course in courseCounts)
            {
                Console.WriteLine($"{course.Course}: {course.Count} student(s)");
            }
            Console.WriteLine();
        }

        public void SearchStudent()
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Course");
            var searchOption = Console.ReadLine();

            List<Student> result = new List<Student>();
            if (searchOption == "1")
            {
                Console.Write("Enter Name to search: ");
                string name = Console.ReadLine();
                result = students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else if (searchOption == "2")
            {
                Console.Write("Enter Course to search: ");
                string course = Console.ReadLine();
                result = students.Where(s => s.Course.Contains(course, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("\nSearch Results:");
            if (result.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                foreach (var student in result)
                {
                    Console.WriteLine(student);
                    Console.WriteLine();
                }
            }
        }

        public void SortStudents()
        {
            Console.WriteLine("Sort by:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Course");

            var sortOption = Console.ReadLine();
            List<Student> sortedList = new List<Student>();

            switch (sortOption)
            {
                case "1":
                    sortedList = students.OrderBy(s => s.Name).ToList();
                    break;
                case "2":
                    sortedList = students.OrderBy(s => s.Age).ToList();
                    break;
                case "3":
                    sortedList = students.OrderBy(s => s.Course).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            Console.WriteLine("\nSorted Students:");
            foreach (var student in sortedList)
            {
                Console.WriteLine(student);
            }
        }

        public void AddFeedbackForStudent()
        {
            Console.Write("Enter Student ID to give feedback: ");
            int studentId = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == studentId);

            if (student != null)
            {
                Console.Write("Enter Lecturer Name: ");
                string lecturerName = Console.ReadLine();
                Console.Write("Enter Feedback: ");
                string feedbackText = Console.ReadLine();

                Lecturer lecturer = new Lecturer(lecturerName, "Unknown Department");
                lecturer.GiveFeedback(student, feedbackText);
                SaveStudents();

                Console.WriteLine("Feedback added successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void ViewFeedbackForStudent()
        {
            Console.Write("Enter Student ID to view feedback: ");
            int studentId = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == studentId);

            if (student != null && student.Feedbacks.Count > 0)
            {
                Console.WriteLine("\nFeedback for " + student.Name + ":");
                foreach (var feedback in student.Feedbacks)
                {
                    Console.WriteLine(feedback);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No feedback found for this student.");
            }
        }
    }
}
