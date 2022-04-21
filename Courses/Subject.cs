using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        List<Course> Courses { get; set; }
    }
}
