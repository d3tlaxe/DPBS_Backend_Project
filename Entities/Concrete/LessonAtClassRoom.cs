using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LessonAtClassRoom : IEntity
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonAndPrelectorPairId { get; set; }
        public int LessonDay { get; set; }
        public int LessonStartTime { get; set; }
    }
}
