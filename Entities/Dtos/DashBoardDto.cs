using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DashBoardDto : IDto
    {
        public int PrelectorCount { get; set; }
        public int LessonCount { get; set; }
        public int ClassRoomCount { get; set; }
        public int StudentCount { get; set; }
        public int PlannedLessonCount { get; set; }
        public int PlannedClassromCount { get; set; }
        public int PlannedPrelectorCount { get; set; }
    }
}
