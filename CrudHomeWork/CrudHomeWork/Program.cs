using CrudHomeWork.Models;
using CrudHomeWork.Services;

namespace CrudHomeWork
{
    internal class Program
    {
        private static string student1UserName = "student1";
        private static string student1Password = "student1";

        private static string student2UserName = "student2";
        private static string student2Password = "student2";

        private static string teacherUserName = "teacher";
        private static string teacherPassword = "teacher";

        private static string directorUserName = "director";
        private static string directorPassword = "director";
        static void Main(string[] args)
        {
            StartFrontEnd();
        }
        public static void StartFrontEnd()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0.Back");
                Console.WriteLine("1.Login");
                Console.Write("Enter : ");
                var alternative = Console.ReadLine();
                if (alternative == "0")
                {
                    Console.WriteLine("Thank you");
                    return;
                }
                if (alternative == "1")
                {
                    LoginPage();
                }

            }

        }
        public static void LoginPage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter name");
                var userName = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();
                if (userName == directorUserName && password == directorPassword)
                {
                    RunDirector();
                }
                else if (userName == teacherUserName && password == teacherPassword)
                {
                    RunTeacher();
                }
                else if (userName == student1UserName && password == student1Password)
                {
                    RunStudent();
                }
                else if (userName == student2UserName && password == student2Password)
                {
                    RunStudent();
                }
            }
        }
        public static void RunTeacher()
        {
            var studentService = new StudentServices();
            var testService = new TestService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0.Back");
                Console.WriteLine("1.Test");
                Console.WriteLine("2.Student");
                Console.WriteLine();
                Console.WriteLine("Enter");
                var alternative = Console.ReadLine();
                if (alternative == "0")
                {
                    Console.WriteLine("Thanks");
                    return;
                }
                else if (alternative == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("0.Back");
                        Console.WriteLine("1.Add test");
                        Console.WriteLine("2.Delete test ");
                        Console.WriteLine("3.Read test");
                        Console.WriteLine("4.Get by id ");
                        Console.WriteLine("5.Update test");
                        Console.WriteLine("6.Get random test");
                        Console.Write("Enter: ");
                        var secondAlternative = Console.ReadLine();
                        if (secondAlternative == "0")
                        {
                            Console.WriteLine("Thanks");
                            return;
                        }
                        else if (secondAlternative == "1")
                        {
                            var test = new Test();
                            Console.WriteLine("Question text");
                            test.QuestionText = Console.ReadLine();
                            Console.WriteLine("A variant");
                            test.AVariant = Console.ReadLine();
                            Console.WriteLine("B variant");
                            test.BVariant = Console.ReadLine();
                            Console.WriteLine("C variant");
                            test.CVariant = Console.ReadLine();
                            Console.WriteLine("Answer A/B/C ");
                            test.Answer = Console.ReadLine();
                            testService.AddTest(test);

                        }
                        else if (secondAlternative == "2")
                        {
                            Console.Write("Enter id ");
                            var Id = Guid.Parse(Console.ReadLine());
                            testService.DeleteTest(Id);
                        }
                        else if (secondAlternative == "3")
                        {
                            var tests = testService.GetAllTest();
                            foreach (var test in tests)
                            {
                                Console.WriteLine($"id : {test.Id}");
                                Console.WriteLine($"Question test : {test.QuestionText}");
                                Console.WriteLine($"A variant : {test.AVariant}");
                                Console.WriteLine($"B variant : {test.BVariant}");
                                Console.WriteLine($"C variant : {test.CVariant}");
                                Console.WriteLine($"Answer A/B/C : {test.Answer}");
                                Console.WriteLine();
                            }

                        }
                        else if (secondAlternative == "4")
                        {
                            Console.WriteLine("Enter id : ");
                            var Id = Guid.Parse(Console.ReadLine());
                            var test = testService.GetById(Id);
                            Console.WriteLine($"Id : {test.Id}");
                            Console.WriteLine($"Question text : {test.QuestionText}");
                            Console.WriteLine($"A variant : {test.AVariant}");
                            Console.WriteLine($"B variant : {test.BVariant}");
                            Console.WriteLine($"C variant : {test.CVariant}");
                            Console.WriteLine($"Answer : {test.Answer}");
                            Console.WriteLine();

                        }
                        else if (secondAlternative == "5")
                        {
                            var test = new Test();
                            Console.WriteLine("Question id ");
                            test.Id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Question text");
                            test.QuestionText = Console.ReadLine();
                            Console.WriteLine("A variant");
                            test.AVariant = Console.ReadLine();
                            Console.WriteLine("B variant ");
                            test.BVariant = Console.ReadLine();
                            Console.WriteLine("C variant");
                            test.CVariant = Console.ReadLine();
                            testService.UpdateTest(test);
                        }
                        else if (secondAlternative == "6")
                        {
                            Console.WriteLine("Enter : ");
                            var choise = int.Parse(Console.ReadLine());
                            var test = testService.GetRandomTests(choise);
                            foreach (var tests in test)
                            {
                                Console.WriteLine($"Id : {tests.Id}");
                                Console.WriteLine($"Question text : {tests.QuestionText}");
                                Console.WriteLine($"A variant : {tests.AVariant}");
                                Console.WriteLine($"B variant : {tests.BVariant}");
                                Console.WriteLine($"C variant : {tests.CVariant}");
                                Console.WriteLine($"Answer : {tests.Answer}");
                                Console.WriteLine();

                            }

                        }
                        Console.ReadKey();
                    }
                }
                else if (alternative == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("0. Quit");
                        Console.WriteLine("1. Add Student");
                        Console.WriteLine("2. Delete Student");
                        Console.WriteLine("3. Read Students");
                        Console.WriteLine("4. Get by id Student");
                        Console.WriteLine("5. Update Student");
                        Console.Write("enter : ");
                        var thirdAlternative = Console.ReadLine();
                        if (thirdAlternative == "0")
                        {
                            Console.WriteLine("Thanks");
                            return;
                        }
                        else if (thirdAlternative == "1")
                        {
                            var student = new Students();
                            Console.WriteLine("First name");
                            student.FirstName = Console.ReadLine();
                            Console.WriteLine("Last name ");
                            student.LastName = Console.ReadLine();
                            Console.WriteLine("Age student ");
                            student.Age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Degree student");
                            student.Degree = Console.ReadLine();
                            Console.WriteLine("Gender student");
                            student.Gender = Console.ReadLine();
                            studentService.AddStudent(student);
                        }
                        else if (thirdAlternative == "2")
                        {
                            Console.Write("Enter id ");
                            var id = Guid.Parse(Console.ReadLine());
                            studentService.DeleteStudent(id);
                        }
                        else if (thirdAlternative == "3")
                        {
                            var students = studentService.GetAllStudent();
                            foreach (var student in students)
                            {
                                Console.WriteLine($"id : {student.Id}");
                                Console.WriteLine($"First Name : {student.FirstName}");
                                Console.WriteLine($"Last Name : {student.LastName}");
                                Console.WriteLine($"Age : {student.Age}");
                                Console.WriteLine($"Degree : {student.Degree}");
                                Console.WriteLine($"Gender : {student.Gender}");
                                Console.WriteLine($"Results : {student.Results}");
                                Console.WriteLine();
                            }
                        }
                        else if (thirdAlternative == "4")
                        {
                            Console.Write("Enter id :");
                            var id = Guid.Parse(Console.ReadLine());
                            var student = studentService.GetById(id);
                            Console.WriteLine($"id : {student.Id}");
                            Console.WriteLine($"First Name : {student.FirstName}");
                            Console.WriteLine($"Last Name : {student.LastName}");
                            Console.WriteLine($"Age : {student.Age}");
                            Console.WriteLine($"Degree : {student.Degree}");
                            Console.WriteLine($"Gender : {student.Gender}");
                            Console.WriteLine($"Results : {student.Results}");
                            Console.WriteLine();
                        }
                        else if (thirdAlternative == "5")
                        {
                            var newStudent = new Students();

                            Console.Write("Id :");
                            newStudent.Id = Guid.Parse(Console.ReadLine());

                            Console.Write("First Name :");
                            newStudent.FirstName = Console.ReadLine();

                            Console.Write("Last name :");
                            newStudent.LastName = Console.ReadLine();

                            Console.Write("Age :");
                            newStudent.Age = int.Parse(Console.ReadLine());

                            Console.Write("Degree :");
                            newStudent.Degree = Console.ReadLine();

                            Console.Write("Gender :");
                            newStudent.Gender = Console.ReadLine();

                            studentService.UpdateStudent(newStudent);
                        }
                        Console.ReadKey();
                    }
                }

            }
            Console.ReadKey();
        }
        public static void RunDirector()
        {
            var teacherService = new TeacherServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Delete Teacher");
                Console.WriteLine("3. Read Teacher");
                Console.WriteLine("4. Get by id Teacher");
                Console.WriteLine("5. Update Teacher");
                Console.Write("enter : ");
                var option = Console.ReadLine();

                if (option == "0")
                {
                    return;
                }
                else if (option == "1")
                {
                    var teacher = new Techaer();
                    Console.Write("First Name :");
                    teacher.FirstName = Console.ReadLine();

                    Console.Write("Last Name :");
                    teacher.LastName = Console.ReadLine();

                    Console.Write("Age :");
                    teacher.Age = int.Parse(Console.ReadLine());

                    Console.Write("Subject :");
                    teacher.Subject = Console.ReadLine();

                    Console.Write("Gender :");
                    teacher.Gender = Console.ReadLine();

                    teacherService.AddTeacher(teacher);
                }
                else if (option == "2")
                {
                    Console.Write("Enter id :");
                    var id = Guid.Parse(Console.ReadLine());
                    teacherService.DeleteTeacher(id);
                }
                else if (option == "3")
                {
                    var teachers = teacherService.GetAllTeachers();
                    foreach (var teacher in teachers)
                    {
                        Console.WriteLine($"id : {teacher.Id}");
                        Console.WriteLine($"First Name : {teacher.FirstName}");
                        Console.WriteLine($"Last Name : {teacher.LastName}");
                        Console.WriteLine($"Age : {teacher.Age}");
                        Console.WriteLine($"Subject : {teacher.Subject}");
                        Console.WriteLine($"Gender : {teacher.Gender}");
                        Console.WriteLine($"Like : {teacher.Likes}");
                        Console.WriteLine($"Dislike : {teacher.DisLikes}");
                        Console.WriteLine();
                    }
                }
                else if (option == "4")
                {
                    Console.Write("Enter id :");
                    var id = Guid.Parse(Console.ReadLine());
                    var teacher = teacherService.GetById(id);
                    Console.WriteLine($"id : {teacher.Id}");
                    Console.WriteLine($"First Name : {teacher.FirstName}");
                    Console.WriteLine($"Last Name : {teacher.LastName}");
                    Console.WriteLine($"Age : {teacher.Age}");
                    Console.WriteLine($"Subject : {teacher.Subject}");
                    Console.WriteLine($"Gender : {teacher.Gender}");
                    Console.WriteLine($"Like : {teacher.Likes}");
                    Console.WriteLine($"Dislike : {teacher.DisLikes}");
                    Console.WriteLine();
                }
                else if (option == "5")
                {
                    var newteacher = new Techaer();

                    Console.Write("Id :");
                    newteacher.Id = Guid.Parse(Console.ReadLine());

                    Console.Write("First Name :");
                    newteacher.FirstName = Console.ReadLine();

                    Console.Write("Last Name :");
                    newteacher.LastName = Console.ReadLine();

                    Console.Write("Age :");
                    newteacher.Age = int.Parse(Console.ReadLine());

                    Console.Write("Subject :");
                    newteacher.Subject = Console.ReadLine();

                    Console.Write("Gender :");
                    newteacher.Gender = Console.ReadLine();

                    teacherService.UpdateTeacher(newteacher);
                }

                Console.ReadKey();
            }
        }

        public static void RunStudent()
        {
            var testService = new TestService();
            var studentService = new StudentServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Test performance");
                Console.WriteLine("2. View test history");
                Console.WriteLine();
                Console.Write("Enter: ");
                var fourthOption = Console.ReadLine();

                if (fourthOption == "0")
                {
                    return;
                }
                else if (fourthOption == "1")
                {
                    Console.Clear();
                    Console.Write("How many tests do you run?: ");
                    var testAmount = int.Parse(Console.ReadLine());

                    var requestTests = testService.GetRandomTests(testAmount);
                    var count = 1;
                    var resultCount = testAmount;
                    var testModels = new Test();
                    foreach (var test in requestTests)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{count}: {test.QuestionText}");
                        Console.Write($"A. {test.AVariant}      B. {test.BVariant}      C. {test.CVariant}\n");
                        Console.Write("Answer A/B/C: ");
                        var answerOption = Console.ReadLine();
                        if (!(answerOption == testModels.Answer))
                        {
                            resultCount--;
                        }
                        count++;
                    }
                    var studentModels = new Students();
                    studentModels.Results.Add(resultCount);
                }
                else if (fourthOption == "2")
                {
                    Console.Clear();
                    Console.WriteLine( "Result");
                    Console.WriteLine();
                    var student = new Students();
                    var count = 1;
                    foreach (var result in student.Results)
                    {
                        Console.Write($"{count} : {result};  ");
                        count++;
                    }

                }
            }


        }
    }
}