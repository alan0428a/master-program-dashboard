using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public double Gpa { get; set; }
        public int Toefl { get; set; }
        public int GreVerbal { get; set; }
        public int GreQuant { get; set; }
        public int WorkExp { get; set; }
        public bool CsCourse { get; set; }
        public string Tags { get; set; }
        public string Link { get; set; }
    }
}
