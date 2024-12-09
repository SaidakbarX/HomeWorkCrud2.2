using CrudHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrudHomeWork.Services;

public class TeacherServices
{
    private string teacherFilePath;
    private List<Techaer> _teachers;
    public TeacherServices()
    {
        teacherFilePath = "../../../Date/Techaerss.json";
        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
        _teachers = new List<Techaer>();
        _teachers = GetAllTeachers();

    }
    public Techaer AddTeacher(Techaer teacher)
    {
        teacher.Id = Guid.NewGuid();
        _teachers.Add(teacher);
        SaveData();
        return teacher;
    }
    public Techaer GetById(Guid id)
    {
        foreach (var teacher in _teachers)
        {
            if (teacher.Id == id) return teacher;
        }
        return null;
    }
    public bool DeleteTeacher(Guid id)
    {
        var deletTeacher = GetById(id);
        if (deletTeacher is null)
        {
            return false;
        }
        _teachers.Remove(deletTeacher);
        SaveData();
        return true;
    }
    public bool UpdateTeacher(Techaer teachers)
    {
        var teacherFromDb = GetById(teachers.Id);
        if (teacherFromDb is null)
        {
            return false;
        }
        var index = _teachers.IndexOf(teacherFromDb);
        _teachers[index] = teachers;
        SaveData();
        return true;

    }
    public List<Techaer> GetAllTeachers()
    {
        return GetTeachers();
    }
    private void SaveData()
    {
        var teacherJson = JsonSerializer.Serialize(_teachers);
        File.WriteAllText(teacherFilePath, teacherJson);
    }
    private List<Techaer> GetTeachers()
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        var teacher = JsonSerializer.Deserialize<List<Techaer>>(teachersJson);
        return teacher;
    }

    

    

}
