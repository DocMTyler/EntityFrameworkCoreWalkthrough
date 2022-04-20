using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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

                foreach (var b in db.Building.ToList())
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
                    Console.WriteLine($"Room Number: {r.RoomNumber} - {r.Description ?? "N/A"}");
                }
*/
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
                }
*/
                //---------------------------------------------------------------------
                //Insert into DB
                /*var building = new Building() { BuildingName = "Testing 123" };

                var existingBuildings = db.Building.Where(b => b.BuildingName == building.BuildingName).ToList();
                
                db.Building.Add(building);
                db.SaveChanges();
                Console.WriteLine($"New building has id {building.BuildingID} ");*/

                //---------------------------------------------------------------------
                //Update DB
                //var room = db.Room.Find(1);

                //room.Description = "Getting tired of updating this row!!";
                /*outScopeRoom.Description = "Getting!!";
                db.Room.Update(outScopeRoom);
                db.SaveChanges();*/

                //--------------------------------------------------------------------
                //Delete from DB
                // get previously inserted building
                /*var building = db.Building
                    .Single(b => b.BuildingID == 5);

                db.Building.Remove(building);
                db.SaveChanges();*/
                /*Delete(6);
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
            InsertStoredProcedureExample();
            GetAllStoredProcedureExample();
            //FromEFStoredProcedureExample();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        /*private static void FromEFStoredProcedureExample()
        {
            using (var context = new ApplicationDbContext())
            {
                var buildings = context.Buildings.FromSqlInterpolated($"BuildingSelectAll").ToList();

                foreach (var b in buildings)
                {
                    Console.WriteLine(b.BuildingName);
                }
            }
        }*/

        public static void Delete(int buildingId)
        {
            using (var db = ApplicationDbContext.GetDBContext())
            {
                var building = new Buildings() { BuildingID = buildingId };
                db.Buildings.Attach(building);
                db.Buildings.Remove(building);
                db.SaveChanges();
            }
        }

        public static void GetAllStoredProcedureExample()
        {
            using (var connection = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                var cmd = new SqlCommand("BuildingSelectAll", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["BuildingName"]}");
                    }
                }
            }
        }

        public static void InsertStoredProcedureExample()
        {
            using (var cn = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                var cmd = new SqlCommand("BuildingInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BuildingName", "Output Test");

                var id = new SqlParameter("@BuildingID", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id);

                cn.Open();

                cmd.ExecuteNonQuery();
                Console.WriteLine($"Created building with id {id.Value}");
            }
        }
    }
}
