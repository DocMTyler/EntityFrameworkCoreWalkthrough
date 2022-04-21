using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Grade
    {
        public int GradeID { get; set; }
        public decimal? Score { get; set; }

        public int GradeItemID { get; set; }
        public GradeItem GradeItem { get; set; }
    }
}
