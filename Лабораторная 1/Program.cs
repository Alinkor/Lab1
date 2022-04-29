using System;

namespace Лабораторная_1
{
    class Program
    {
        static void Main (string[] args)
        {
            Person p1 = new("Cmirnov", "Sasha", new DateTime(1999, 05, 01));
            Person p2 = new("Cmirnov", "Sasha", new DateTime(1999, 05, 01));

            Console.WriteLine("Equality of objects");
            Console.WriteLine (p1.Equals(p2));
            Console.WriteLine("Link equality");                
            Console.WriteLine((object)p1 == (object)p2);
            Console.WriteLine ("\nHash Codes: \n{0}  \n{1}", p1.GetHashCode(), p2.GetHashCode());  

            Student std = new Student();
            std = new Student(new Person("Nikolay", "Gudkov", new DateTime(1998, 9, 4)), Education.Вachelor, 123);
            std.AddExams(
                new Exam("Mathematics", 3, new DateTime(2009, 2, 1)),
                new Exam("Russian", 4, new DateTime(2009, 6, 30)),
                new Exam("Physics", 2, new DateTime(2010, 12, 23)));
            std.AddTest(
                new Test("Russian", true),
                new Test("History", true));

            Console.WriteLine(std.ToString());
            Console.WriteLine("\n");
            Console.WriteLine(std.InfStud);
            Console.WriteLine("\n");

            Console.WriteLine("Work with the method DeepCopy");
            Student stdClone = (Student)std.DeepCopy();
            std.InfStud = new Person("Ivan", "Frolov", new DateTime(1995, 5, 5));
            std.FormStud = Education.SecondEducation;
            std.Number = 204;
            std.AddExams(
                new Exam("Mathematics", 5, new DateTime(2019, 2, 1)),
                new Exam("Programming", 5, new DateTime(2019, 6, 30)));
            Console.WriteLine(std.ToString());
            Console.WriteLine(stdClone.ToString());
            Console.WriteLine("\n");

            try
            {
                std.Number = 700;
            }
            catch (ArgumentOutOfRangeException mes)
            {
                Console.WriteLine(mes.Message);
            }
            Console.WriteLine("\n");

            foreach (var res in std.Results())
                Console.WriteLine(res.ToString());
            Console.WriteLine("\n");

            foreach (var task in std.ExamsGrade(3))
                Console.WriteLine(task.ToString());
            Console.WriteLine("\n");

            Console.WriteLine("Passed both test or exam");
            foreach (var ress in std.ExamsOrTest(2))
                Console.WriteLine(ress.ToString());
            Console.WriteLine("\n");


            Console.WriteLine("Passed both test and exam");
            foreach (var ress in std.ExamsAndTest(2))
                Console.WriteLine(ress.ToString());
            Console.WriteLine("\n");
        }
    }
}
