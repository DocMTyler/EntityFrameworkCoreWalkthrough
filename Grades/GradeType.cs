using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class GradeType
    {
        public int GradeTypeID { get; set; }
        public string GradeTypeName { get; set; }

        List<GradeItem> GradeItems { get; set; }
    }
}
