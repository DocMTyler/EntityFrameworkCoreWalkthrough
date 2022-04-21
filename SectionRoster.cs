using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class SectionRoster
    {
        public int SectionRosterID { get; set; }

        public int SectionID { get; set; }
        public Section Section { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int CurrentGrade { get; set; }
        List<Grade> Grades { get; set; }

    }
}
