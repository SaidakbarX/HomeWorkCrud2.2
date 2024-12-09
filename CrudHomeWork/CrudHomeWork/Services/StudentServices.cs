using CrudHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrudHomeWork.Services;

public class StudentServices

{
    private string studentFilePath;
    private List<Students> _students;
    public StudentServices()
    {
        studentFilePath = "../../../Date/Students.json";
        if(File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
        _students = new List<Students>();
        
        _students = GetAllStudent();

    }
    public Students AddStudent(Students student)
    {
        student.Id = Guid.NewGuid();
        _students.Add(student);
        SaveData();
        return student;
    }
    public Students GetById (Guid id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id) return student;
        }
        return null;
    }
    public bool DeleteStudent(Guid id)
    {
        var deletStudent = GetById(id);
        if (deletStudent is null)
        {
            return false;
        }
        _students.Remove(deletStudent);
        SaveData();
        return true;
    }
    public bool UpdateStudent(Students students)
    {
        var studentFromDb = GetById(students.Id);
        if (studentFromDb is null)
        {
            return false;
        }
        var index = _students.IndexOf(studentFromDb);
        _students[index] = students;
        SaveData();
        return true;

    }
    public List<Students> GetAllStudent ()
    {
        return GetStudents();
    }
    public void SaveData()
    {
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(studentFilePath, studentJson);
    }
    private List<Students> GetStudents()
    {
        var studentsJson = File.ReadAllText(studentFilePath);
        var students = JsonSerializer.Deserialize<List<Students>>(studentsJson);
        return students;
    }
}
