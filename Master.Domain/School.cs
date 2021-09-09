using System;

namespace Master.Domain
{
    public class School : IEquatable<School>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country{ get; set; }
        public string State { get; set; }
        public int Ranking { get; set; }
        public bool Equals(School other)
        {
            if (other == null)
                return false;

            if (this.Name == other.Name &&
                this.Country == other.Country &&
                this.State == other.State)
                return true;
            else
                return false;
        }
    }

    
}
