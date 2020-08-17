using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValkyrieGame.Models
{
    class GameObject
    {
        public Guid Id { get; set; }

        public GameObject()
        {
            Id = Guid.NewGuid();
        }
    }
}
