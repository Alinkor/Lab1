using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_1
{
    public class Test
    {
        public string subject { get; set; }
        public bool pass { get; set; }

        public Test(string subject, bool pass)
        {
            this.subject = subject;
            this.pass = pass;
        }

        public Test()
        {
            subject = "Math";
            pass = true;
        }

        public override string ToString()
        {
            return string.Format("\nTest subject: {0}   Passed Test = {1}", subject, pass);
        }
    }
}
