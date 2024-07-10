using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StudentLessonDto : IDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonCode { get; set; }
        public int Period { get; set; }
        public int Credit { get; set; }
        public int LessonHour { get; set; }
        public int Capacity { get; set; }
        public bool isImperative { get; set; }
        public int PrelectorId { get; set; }
        public string PrelectorName { get; set; }
        public string PrelectorSurname { get; set; }
        public string PrelectorAppellation { get; set; }

    }
}
