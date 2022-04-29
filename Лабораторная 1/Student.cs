using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Лабораторная_1
{
    public class Student : Person, IDateAndCopy
    {
        private Education formStud;
        private int number;
        private ArrayList tests;
        private ArrayList exams;


        public Student() : base()
        {
            formStud = Education.SecondEducation;
            number = 101;
            exams = new ArrayList();
            tests = new ArrayList();
        }

        public Student(Person p, Education formStud, int number) : base(p.FirstName, p.LastName, p.DayOfBirth)
        {
            this.FormStud = formStud;
            this.number = number;
            exams = new ArrayList();
            tests = new ArrayList();
        }


        public Person InfStud
        {
            get 
            {
                Person a = new Person(firstName, lastName, dayOfBirth);
                return a; 
            }
            set
            {
                firstName = value.FirstName;
                lastName = value.LastName;
                dayOfBirth = value.DayOfBirth;
            }
        }

        public Education FormStud
        {
            get { return this.formStud; }
            set { this.formStud = value; }
        }

        public int Number
        {
            get { return this.number; }
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Error! Number out of range from 100 to 599");
                }
                number = value;
            }
        }

        public ArrayList Exams
        {
            get { return exams; }
            set { exams = value; }
        }


        public bool this[Education index] => this.formStud == index;


        public void AddExams(params Exam[] infexamsstud)
        {
            exams.AddRange(infexamsstud);
        }

        public void AddTest(params Test[] infTest)
        {
            tests.AddRange(infTest);
        }

        public double SrGrade
        {
            get
            {
                double result = 0;
                int kol = 0;
                foreach (Exam item in Exams)
                {
                    result += item.grade;
                    kol++;
                }
                result /= kol;
                if (kol != 0) return result;
                else return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder stroka = new StringBuilder();
            foreach (var strk in Exams)
            {
                stroka.Append($"{strk}");
            }
            StringBuilder stroka2 = new StringBuilder();
            foreach (var strk2 in tests)
            {
                stroka2.Append($"{strk2}");
            }
            return string.Format("\n{0}\nForm of education: {1}\nGroup number: {2, 7} \nMiddle grade: {3, 6} \nList exams: \n\n{4} \n\nList tests: \n{5}", InfStud, formStud, Number, SrGrade, stroka, stroka2);
        }

        public override string ToShortString()
        {
            if (SrGrade == 0) return string.Format("Student: {0}\nForm of education: {1}\nGroup number: {2, 6}", InfStud, formStud, number);
            else return string.Format("Student: {0}\nForm of education: {1}\nGroup number: {2, 6} \nMiddle grade: {3, 6}", InfStud, formStud, number, SrGrade);
        }

        public override DateTime Date { get; set; }

        public override object DeepCopy()
        {
            var std = new Student(InfStud, formStud, number);
            foreach (Exam exam in exams)
            {
                std.AddExams(exam);
            }
            foreach (Test test in tests)
            {
                std.AddTest(test);
            }
            return std;
        }

        public IEnumerable Results()
        {
            foreach (var exam in exams)
                yield return exam;
            foreach (var test in tests)
                yield return test;
        }

        public IEnumerable ExamsGrade(int minRate)
        {
            foreach (var exam in exams)
            {
                if (((Exam)exam).grade > minRate)
                    yield return exam;
            }
        }

        public IEnumerable ExamsOrTest(int minRate)
        {
            foreach (var exam in exams)
            {
                if (((Exam)exam).grade > minRate)
                    yield return exam;
            }
            foreach (var test in tests)
                if (((Test)test).pass ==true)
                    yield return test;
        }

        public IEnumerable ExamsAndTest(int minRate)
        {
            foreach (var exam in exams)
            {
                foreach (var test in tests)
                {
                    if ((((Exam)exam).subject == ((Test)test).subject) && (((Exam)exam).grade > minRate) && (((Test)test).pass == true))
                        yield return test;
                }
            }
        }
    }
}
