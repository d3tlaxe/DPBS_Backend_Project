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
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, MyContext>, ILessonDal
    {

        public List<Lesson> GetByImperative(bool isImperative)
        {
            using (MyContext context = new MyContext())
            {
                var result = from l in context.Lessons
                             where l.isImperative == isImperative
                             select new Lesson
                             {
                                 Id = l.Id,
                                 Name = l.Name,
                                 Period = l.Period,
                                 Credit = l.Credit,
                                 LessonHours = l.LessonHours,
                                 Capacity   = l.Capacity,
                                 isImperative = l.isImperative
                             };
                return result.ToList();
            }
        }

        public List<Lesson> GetHighClassLessons(int myPeriod)
        {
            using (MyContext context = new MyContext())
            {
                var result = from l in context.Lessons
                             where l.Period > myPeriod
                             select new Lesson
                             {
                                 Id = l.Id,
                                 Name = l.Name,
                                 Period = l.Period,
                                 Credit = l.Credit,
                                 LessonHours = l.LessonHours,
                                 Capacity = l.Capacity,
                                 isImperative = l.isImperative
                             };
                return result.ToList();
            }
        }

 
    }
}
