using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MyContext>, IUserDal
    {
        public List<StudentDetailDto> GetStudentDetails(int userId)
        {
            
            using (MyContext context = new MyContext())
            {
                var result = from u in context.Users
                             join s in context.StudentDetails
                             on u.Id equals s.UserId
                             join sp in context.StudentPeriods
                             on u.Id equals sp.UserId
                             where u.Id == userId
                             select new StudentDetailDto
                             {
                                 Id = u.Id,
                                 Email = u.EMail,
                                 Password = u.Password,
                                 UserTypeId = u.UserTypeId,
                                 TCNo = s.TCNo,
                                 Name = s.Name,
                                 Surname = s.Surname,
                                 Period = sp.Period,
                                 Phone = s.Phone,
                                 Address = s.Address,
                             };
                return result.ToList();
            }
          
        }



        public List<PrelectorDetailDto> GetPrelectorDetails(int userId)
        {

            using (MyContext context = new MyContext())
            {
                var result = from u in context.Users
                             join p in context.PrelectorDetails
                             on u.Id equals p.UserId
                             join pa in context.PrelectorAppellations
                             on p.AppellationId equals pa.Id
                             where u.Id == userId
                             select new PrelectorDetailDto
                             {
                                 Id = u.Id,
                                 Email = u.EMail,
                                 Password = u.Password,
                                 UserTypeId = u.UserTypeId,
                                 TCNo = p.TCNo,
                                 Name = p.Name,
                                 Surname = p.Surname,
                                 AppellationName = pa.Appellation,
                                 Phone = p.Phone,
                                 Address = p.Address,
                             };
                return result.ToList();
            }

        }

    }
}
