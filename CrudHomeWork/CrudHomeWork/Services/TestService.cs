using CrudHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrudHomeWork.Services;

public class TestService
{
    private string testFilePath;
    private List<Test> _tests;
    public TestService()
    {
        testFilePath = "../../../Date/Test.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
        _tests = new List<Test>();
        
        _tests = GetAllTest();

    }
    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        _tests.Add(test);
        SaveData();
        return test;
    }
    public Test GetById(Guid id)
    {
        foreach (var test in _tests)
        {
            if (test.Id == id) return test;
        }
        return null;
    }
    public bool DeleteTest(Guid id)
    {
        var delettest = GetById(id);
        if (delettest is null)
        {
            return false;
        }
        _tests.Remove(delettest);
        SaveData();
        return true;
    }
    public bool UpdateTest(Test tests)
    {
        var testFromDb = GetById(tests.Id);
        if (testFromDb is null)
        {
            return false;
        }
        var index = _tests.IndexOf(testFromDb);
        _tests[index] = tests;
        SaveData();
        return true;

    }
    public List<Test> GetAllTest()
    {
        return GetTests();
    }
    public List<Test> GetRandomTests(int count)
    {
        if (count >= _tests.Count)
        {
            return _tests;
        }
        List<Test> tests = new List<Test>();
        var rand = new Random();
        for (var  i = 0; i < count;)
        {
            var alternative = rand.Next(0,_tests.Count);
            if (tests.Contains(_tests[alternative]) is false)
            {
                tests.Add(_tests[alternative]);
                i++;
            }

        }
        return tests;
    }
    private void SaveData()
    {
        var testJson = JsonSerializer.Serialize(_tests);
        File.WriteAllText(testFilePath, testJson);
    }
    private List<Test> GetTests()
    {
        var testsJson = File.ReadAllText(testFilePath);
        var test = JsonSerializer.Deserialize<List<Test>>(testsJson);
        return test;
    }

}
