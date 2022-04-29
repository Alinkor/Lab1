using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_1
{
    public class Exam : IDateAndCopy
    {
        public string subject;
        public int grade;
        public DateTime dateEx;


        public Exam(string subject, int grade, DateTime dateEx)
        {
            this.subject = subject;
            this.grade = grade;
            this.dateEx = dateEx;
        }

        public Exam() : this("Math", 5, new DateTime(2008, 6, 1)) { }

        public override string ToString()
        {
            return string.Format("\n{0, -18} {1,-4} Date of exam: {2, -5}", subject, grade, dateEx.ToShortDateString());
        }

        public object DeepCopy()
        {
            return (new Exam(subject, grade, dateEx));
        }

        public DateTime Date
        {
            get { return dateEx; }
            set { dateEx = value; }
        }
    }
}
