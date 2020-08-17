using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValkyrieGame.Models
{
    class Game : GameObject
    {
        public IList<Room> Rooms { get; set; }
        public IList<Door> Doors { get; set; }

        public string Name { get; set; }

        public Game() : base()
        {
            Rooms = new List<Room>();
            Doors = new List<Door>();
        }

        public Game(string name) : this()
        {
            Name = name;
        }
    }
}
