using System;
using System.Collections.Generic;
using System.IO;

public class TeacherDataHandler
{
    private const string FilePath = "C:\\Users\\kshiv\\OneDrive\\Desktop\\Teachersdata.txt";

    // Method to add a new teacher to the text file.
    public void AddTeacher(Teacher teacher)
    {
        try
        {
            using (StreamWriter writer = File.AppendText(FilePath))
            {
                writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while writing to the file: {e.Message}");
        }
    }

    // Method to retrieve all teachers from the text file.
    public List<Teacher> GetAllTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();
        try
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Teacher teacher = new Teacher
                        {
                            ID = int.Parse(parts[0]),
                            Name = parts[1],
                            Class = parts[2],
                            Section = parts[3]
                        };
                        teachers.Add(teacher);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while reading from the file: {e.Message}");
        }
        return teachers;
    }

    // Method to update teacher data by ID.
    public void UpdateTeacher(int id, Teacher updatedTeacher)
    {
        try
        {
            List<Teacher> teachers = GetAllTeachers();
            Teacher teacherToUpdate = teachers.Find(t => t.ID == id);
            if (teacherToUpdate != null)
            {
                teacherToUpdate.Name = updatedTeacher.Name;
                teacherToUpdate.Class = updatedTeacher.Class;
                teacherToUpdate.Section = updatedTeacher.Section;

                // Re-write the entire file with updated data.
                File.WriteAllText(FilePath, string.Empty);
                foreach (Teacher teacher in teachers)
                {
                    AddTeacher(teacher);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while updating the file: {e.Message}");
        }
    }
}
