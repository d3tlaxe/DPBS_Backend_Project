using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProgramForStudentDto : IDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string LessonName { get; set; }
        public string LessonCode { get; set; }
        public string PrelectorName { get; set; }
        public string PrelectorSurname { get; set; }
        public string PrelectorAppellation { get; set; }
        public string ClassRoomName { get; set; }
        public string LessonDay { get; set; }
        public string LessonStartTime { get; set; }
    }
}
