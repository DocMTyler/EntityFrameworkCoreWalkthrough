using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Room
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }

        public int BuildingID { get; set; }
        public Building Building { get; set; }
    }
}
