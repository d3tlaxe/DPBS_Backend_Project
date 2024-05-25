using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class LessonsOfPrelectorDto : IDto
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Period { get; set; }
        public int Credit { get; set; }
        public int LessonHours { get; set; }
        public int Capacity { get; set; }
        public bool isImperative { get; set; }
    }
}
