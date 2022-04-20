using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entity Framework");

            var outScopeRoom = new Room()
            {
                RoomID = 1,
                RoomNumber = 100,
                BuildingID = 1,
                Description = "Out of Scope Update"
            };
            
            using (var db = ApplicationDbContext.GetDBContext())
            {
                //---------------------------------------------------------------
                //Buildings queries
                /*var building = db.Building.Find(1);
                var building2 = db.Building.Single(b => b.BuildingID == 2);
                

                Console.WriteLine(building.BuildingName);
                Console.WriteLine(building2.BuildingName);
                Console.WriteLine();

                foreach(var b in db.Building.ToList())
                {
                    Console.WriteLine($"{b.BuildingID} - {b.BuildingName}");
                }*/

                //Console.WriteLine();

                //Rooms queries
                /*var rooms = db.Room
                    .Where(r => r.RoomNumber >= 200)
                    .OrderBy(r => r.RoomNumber)
                    .ThenBy(r => r.Description);

                foreach (var r in rooms)
                {
                    Console.WriteLine($"{r.RoomNumber} {r.Description ?? "N/A"}");
                }*/

                //--------------------------------------------------------------------
                //Joins
                /*var buildings = db.Building
                    .Include(b => b.Rooms
                        .Where(r => r.RoomNumber >= 200)
                        .OrderBy(r => r.RoomNumber))
                    .ToList();

                foreach (var b in buildings)
                {
                    Console.WriteLine($"{b.BuildingName}");
                    Console.WriteLine("--------------------------");
                    foreach (var room in b.Rooms)
                    {
                        Console.WriteLine($"{room.RoomNumber} {room.Description ?? "N/A"}");
                    }
                }*/

                /*var rooms = db.Room
                    .Include(r => r.Building)
                    .Select(r => new RoomSummary()
                    {
                        Building = r.Building.BuildingName,
                        RoomID = r.RoomID,
                        RoomNumber = r.RoomNumber
                    })
                    .ToList();

                foreach (var r in rooms)
                {
                    Console.WriteLine($"{r.RoomID}  {r.RoomNumber} {r.Building}");
                }*/

                //---------------------------------------------------------------------
                //Insert into DB
                /*var building = new Building() { BuildingName = "Testing 123" };

                db.Building.Add(building);
                db.SaveChanges();

                Console.WriteLine($"New building has id {building.BuildingID} ");*/

                //---------------------------------------------------------------------
                //Update DB
                /*var room = db.Room.Find(1);

                room.Description = "Updated Description";*/
                /*outScopeRoom.Description = "Updating the out of scope update";
                db.Room.Update(outScopeRoom);
                db.SaveChanges();*/

                //--------------------------------------------------------------------
                //Delete from DB
                // get previously inserted building
                /*var building = db.Building
                    .Single(b => b.BuildingName == "Testing 123");

                db.Building.Remove(building);*/
                /*Delete(4);
                db.SaveChanges();*/

                //---------------------------------------------------------------------
                //Aggregates
                /*var grouping = db.Room
                    .Include(r => r.Building)
                    .GroupBy(r => r.Building.BuildingName)
                    .Select(g => new
                    {
                        Building = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                foreach (var g in grouping)
                {
                    Console.WriteLine($"{g.Building} - {g.Count}");
                }*/
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void Delete(int buildingId)
        {
            using (var db = ApplicationDbContext.GetDBContext())
            {
                var building = new Building() { BuildingID = buildingId };
                db.Building.Attach(building);
                db.Building.Remove(building);
                db.SaveChanges();
            }
        }
    }
}
