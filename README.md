# Student Management System

## Overview

The **Student Management System** (SMS) is a console application designed to manage students and their feedback. It allows for adding, viewing, updating, and deleting student records. The system also facilitates lecturers in providing feedback to students and viewing their feedback. This application makes use of XML serialization to persist student data and feedback across sessions.

## Features

- **Add Student**: Add a new student with details such as ID, name, age, and course.
- **View Students**: View the list of all students in the system.
- **Update Student**: Update the details of an existing student.
- **Delete Student**: Delete a student record from the system.
- **View Student Summary**: Get a summary of the total number of students and a breakdown by course.
- **Search Student**: Search for students by name or course.
- **Sort Students**: Sort the student list by name, age, or course.
- **Add Feedback for Student**: Lecturers can provide feedback for students.
- **View Feedback for Student**: View the feedback provided to a specific student.

## Requirements

- **.NET Framework** or **.NET Core** (for running C# applications).
- **XML File Handling**: Data is stored in an XML file (`StudentManagementSystem.xml`) located on the desktop, making it easy to store and load student data.

## Installation

1. Clone the repository or download the project files to your local machine.
2. Open the project in Visual Studio or any C# compatible IDE.
3. Build and run the project.

## Usage

Once the application is running, the user will be prompted with a menu of available options:

1. **Add Student**: Enter student details to add a new student.
2. **View Students**: Display a list of all registered students.
3. **Update Student**: Update the details of an existing student by entering the student ID.
4. **Delete Student**: Delete a student by their ID.
5. **View Student Summary**: View the total number of students and a breakdown by course.
6. **Search Student**: Search students by name or course.
7. **Sort Students**: Sort students by name, age, or course.
8. **Add Feedback for Student**: Lecturers can give feedback to a student.
9. **View Feedback for Student**: View feedback provided for a student.

To exit the system, select option 10.

## Example Workflow

1. Add a student by entering their ID, name, age, and course.
2. View the list of students, update details, or delete students as needed.
3. A lecturer can add feedback for a student, which includes the lecturer's name and feedback text.
4. View the feedback provided for a student.

## How It Works

- **Classes**:
    - `Student`: Represents a student with properties like `Id`, `Name`, `Age`, `Course`, and a list of `Feedback` items.
    - `Feedback`: Represents feedback given to a student, including the `LecturerName`, `FeedbackText`, and `Date`.
    - `Lecturer`: Represents a lecturer who can provide feedback to students.
    - `StudentManagementSystem`: Handles the logic for adding, deleting, updating, and viewing students and their feedback.

- **Data Storage**: Student data and feedback are stored in an XML file located on the desktop (`StudentManagementSystem.xml`). The application uses XML serialization to save and load student data.

## Future Improvements

- Implement user authentication to secure the system.
- Allow multiple lecturers to give feedback to the same student.
- Add validation for user inputs (e.g., ensuring a valid ID is entered).
- Support for exporting student data to other formats (e.g., CSV, JSON).
