using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProgramForPrelectorDto : IDto
    {
        public int Id { get; set; }
        public int PrelectorId { get; set; }
        public string LessonName { get; set; }
        public string LessonCode { get; set; }
        public string ClassRoomName { get; set; }

        public int LessonDayId { get; set; }
        public string LessonDay { get; set; }
        public int LessonHourId { get; set; }
        public string LessonStartTime { get; set; }
    }
}
