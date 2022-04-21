using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Period
    {
        public int PeriodID { get; set; }
        public string PeriodName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        List<Section> Sections { get; set; }
    }
}
