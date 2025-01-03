using ConsoleApp69;

var sms = new StudentManagementSystem();
while (true)
{
    Console.WriteLine("\nStudent Management System");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Students");
    Console.WriteLine("3. Update Student");
    Console.WriteLine("4. Delete Student");
    Console.WriteLine("5. View Student Summary");
    Console.WriteLine("6. Search Student");
    Console.WriteLine("7. Sort Students");
    Console.WriteLine("8. Add Feedback for Student");
    Console.WriteLine("9. View Feedback for Student");
    Console.WriteLine("10. Exit");
    Console.WriteLine();
    Console.Write("Choose an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddStudent(sms);
            break;
        case "2":
            ViewStudents(sms);
            break;
        case "3":
            UpdateStudent(sms);
            break;
        case "4":
            DeleteStudent(sms);
            break;
        case "5":
            sms.ViewStudentSummary();
            break;
        case "6":
            sms.SearchStudent();
            break;
        case "7":
            sms.SortStudents();
            break;
        case "8":
            sms.AddFeedbackForStudent();
            break;
        case "9":
            sms.ViewFeedbackForStudent();
            break;
        case "10":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

static void AddStudent(StudentManagementSystem sms)
{
    var student = new Student();
    Console.Write("Enter Student ID: ");
    student.Id = int.Parse(Console.ReadLine());
    Console.Write("Enter Student Name: ");
    student.Name = Console.ReadLine();
    Console.Write("Enter Student Age: ");
    student.Age = int.Parse(Console.ReadLine());
    Console.Write("Enter Student Course: ");
    student.Course = Console.ReadLine();
    sms.AddStudent(student);
    Console.WriteLine("Student added successfully.");
    Console.WriteLine();
}

static void ViewStudents(StudentManagementSystem sms)
{
    var students = sms.GetStudents();
    Console.WriteLine("\nStudent List:");
    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }
    foreach (var student in students)
    {
        Console.WriteLine(student);
        Console.WriteLine();
    }
}

static void UpdateStudent(StudentManagementSystem sms)
{
    Console.Write("Enter Student ID to update: ");
    int id = int.Parse(Console.ReadLine());
    var student = new Student { Id = id };
    Console.Write("Enter new Student Name: ");
    student.Name = Console.ReadLine();
    Console.Write("Enter new Student Age: ");
    student.Age = int.Parse(Console.ReadLine());
    Console.Write("Enter new Student Course: ");
    student.Course = Console.ReadLine();
    sms.UpdateStudent(student);
    Console.WriteLine("Student updated successfully.");
    Console.WriteLine();
}

static void DeleteStudent(StudentManagementSystem sms)
{
    Console.Write("Enter Student ID to delete: ");
    int id = int.Parse(Console.ReadLine());
    sms.DeleteStudent(id);
    Console.WriteLine("Student deleted successfully.");
    Console.WriteLine();
}