using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValkyrieGame.Models
{
    class Door : GameObject
    {
        public Room FirstRoom { get; set; }
        public Room SecondRoom { get; set; }

        public Door() : base()
        {

        }

        public static Door CreateBetween(Room room1, Room room2)
        {
            var door = new Door
            {
                FirstRoom = room1,
                SecondRoom = room2
            };

           // var door = new Door();

            room1.Doors.Add(door);
            room2.Doors.Add(door);

            return door;
        }
    }
}
