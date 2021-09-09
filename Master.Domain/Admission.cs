using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain
{
    public class Admission
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
    }
}
