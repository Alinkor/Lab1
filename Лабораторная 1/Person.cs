using System;
using System.Text;
using System.Collections;


namespace Лабораторная_1
{
    public class Person: IDateAndCopy
    {
        protected string firstName;
        protected string lastName;
        protected DateTime dayOfBirth;

        public Person(string firstName, string lastName, DateTime dayOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dayOfBirth = dayOfBirth;
        }

        public Person() : this ("Aleksey", "Ivanov", new DateTime(1900, 7, 1)) { }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public DateTime DayOfBirth
        {
            get { return this.dayOfBirth; }
            set { this.dayOfBirth = value; }
        }

        public int YearOfBirth
        {
            get { return dayOfBirth.Year; }
            set { dayOfBirth = new DateTime(value, dayOfBirth.Month, dayOfBirth.Day); }
        }
       

        public override string ToString()
        {
            return string.Format("Student: {0, 16} {1}\nDate of birth: {2, 14}", firstName, lastName, dayOfBirth.ToShortDateString());
        }

        public virtual string ToShortString()
        {
            return "\n" + "Firstname: " + firstName + "\n" + "Lastname: " + lastName;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)        
            {
                return false;
            }
            var a = obj as Person;
            if (a is null)
            {
                return false;
            }
            return this.FirstName == a.FirstName && this.LastName == a.LastName && this.DayOfBirth == a.DayOfBirth;
        }

        public static bool operator ==(Person b, Person c) => b.Equals(c);

        public static bool operator != (Person d, Person e) => !(d == e);

        

        public virtual object DeepCopy()
        {
            return (new Person(this.FirstName, this.LastName, this.DayOfBirth));
        }

        public virtual DateTime Date { get; set; }

        public override int GetHashCode()
        {
            return firstName.GetHashCode() + lastName.GetHashCode() + dayOfBirth.GetHashCode();
        }
    }

    /// ////////////////////////////////

    public enum Education { Specialist, Вachelor, SecondEducation }

}
