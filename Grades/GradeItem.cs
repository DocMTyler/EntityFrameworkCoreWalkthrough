using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class GradeItem
    {
        public int GradeItemID { get; set; }
        public int PointsPossible { get; set; }
        public string Description { get; set; }

        public int GradeTypeID { get; set; }
        public GradeType GradeType { get; set; }   

        public List<Grade> Grades { get; set; }
    }
}
