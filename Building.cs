using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Buildings
    {
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
