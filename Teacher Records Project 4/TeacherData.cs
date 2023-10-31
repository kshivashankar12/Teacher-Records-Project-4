using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        TeacherDataHandler dataHandler = new TeacherDataHandler();

        // Add a new teacher
        Teacher newTeacher = new Teacher
        {
            ID = 1,
            Name = "Shiva",
            Class = "Science",
            Section = "A"
        };
        dataHandler.AddTeacher(newTeacher);

        // Retrieve all teachers
        List<Teacher> teachers = dataHandler.GetAllTeachers();
        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
        }

        // Update a teacher's data
        Teacher updatedTeacher = new Teacher
        {
            ID = 2,
            Name = "Suresh",
            Class = "english",
            Section = "B"
        };
        dataHandler.UpdateTeacher(1, updatedTeacher);
    }
}
