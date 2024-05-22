using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClassRoomDal : EfEntityRepositoryBase<ClassRoom, MyContext>, IClassRoomDal
    {
        public List<ClassRoom> GetBiggerThanParameter(int capacity)
        {
            using (MyContext context = new MyContext())
            {
                var result = from c in context.ClassRooms
                             where c.MaxCapacity > capacity
                             select new ClassRoom
                             {
                                 Id = c.Id,
                                 RoomName = c.RoomName,
                                 MaxCapacity = c.MaxCapacity,
                                 
                             };
                return result.ToList();
            }
        }
    }
}
