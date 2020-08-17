using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValkyrieGame.Models;

namespace ValkyrieGame.Builder
{
    class RoomBuilder
    {
        private Game _game;

        private RoomBuilder() { }

        public static RoomBuilder Init()
        {
            return new RoomBuilder();
        }
    }
}
