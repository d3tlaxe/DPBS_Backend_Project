using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ClassRoom : IEntity
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int MaxCapacity { get; set; }
    }
}
