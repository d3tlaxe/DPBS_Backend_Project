using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
    }
}
