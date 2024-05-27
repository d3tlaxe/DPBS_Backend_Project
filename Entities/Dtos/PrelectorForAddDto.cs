﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PrelectorForAddDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TCNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AppellationId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
