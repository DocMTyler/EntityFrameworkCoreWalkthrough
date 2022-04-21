using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Course
    {
        public int CourseID { get; set; } 
        public string CourseName { get; set; }
        public decimal CreditHours { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        
    }
}
