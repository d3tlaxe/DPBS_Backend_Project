using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PrelectorsOfLessonDto :IDto
    {

        public int Id { get; set; }
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public string TCNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Appellation { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
