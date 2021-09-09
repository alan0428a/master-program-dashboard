using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain
{
    public class Program : IEquatable<Program>
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Department { get; set; }
        public string Url { get; set; }

        public bool Equals(Program other)
        {
            if (other == null)
                return false;

            if (this.Name == other.Name &&
                this.SchoolId == other.SchoolId)
                return true;
            else
                return false;
        }
    }
}
