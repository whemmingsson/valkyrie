using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValkyrieGame.Models
{
    class Room : GameObject
    {
        public string Name { get; set; }

        public IList<Door> Doors { get; set; }

        public Room() : base()
        {
            Doors = new List<Door>();
        }

        public Room(string name) : this()
        {
            Name = name;
        }
    }
}
