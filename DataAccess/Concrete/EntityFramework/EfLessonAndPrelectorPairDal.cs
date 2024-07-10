using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLessonAndPrelectorPairDal : EfEntityRepositoryBase<LessonAndPrelectorPair, MyContext>, ILessonAndPrelectorPairDal
    {
        public List<LessonsOfPrelectorDto> GetByPrelectorId(int prelectorId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from lapp in context.LessonAndPrelectorPairs
                             join l in context.Lessons
                             on lapp.LessonId equals l.Id
                             where lapp.UserId == prelectorId
                             select new LessonsOfPrelectorDto
                             {
                                 Id = lapp.Id,
                                 LessonId = lapp.LessonId,
                                 UserId = lapp.UserId,
                                 Name = l.Name,
                                 Code = l.Code,
                                 Period = l.Period,
                                 Credit = l.Credit,
                                 LessonHours = l.LessonHours,
                                 Capacity = l.Capacity,
                                 isImperative = l.isImperative,
                             };

                return result.ToList();
            }
        }

        public List<PrelectorsOfLessonDto> GetByLessonId(int lessonId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from lapp in context.LessonAndPrelectorPairs
                             join pd in context.PrelectorDetails
                             on lapp.UserId equals pd.UserId
                             join pa in context.PrelectorAppellations
                             on pd.AppellationId equals pa.Id
                             where lapp.LessonId == lessonId
                             select new PrelectorsOfLessonDto
                             {
                                 Id = lapp.Id,
                                 LessonId = lapp.LessonId,
                                 UserId = lapp.UserId,
                                 TCNo = pd.TCNo,
                                 Name = pd.Name,
                                 Surname = pd.Surname,
                                 Appellation = pa.Appellation,
                                 Phone = pd.Phone,
                                 Address = pd.Address
                             };

                return result.ToList();
            }
        }

        public void AddByParameter(int lessonId, int prelectorId)
        {
            using (MyContext context = new MyContext())
            {
                LessonAndPrelectorPair pair = new LessonAndPrelectorPair
                {
                    LessonId = lessonId,
                    UserId = prelectorId
                };
                var addedEntity = context.Entry(pair);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }






    }
}
