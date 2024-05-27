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
    public class EfStudentLessonDal : EfEntityRepositoryBase<StudentLesson, MyContext>, IStudentLessonDal
    {
        public List<StudentLesson> GetByPairId(int pairId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from sl in context.StudentLessons
                             where sl.PairId == pairId
                             select new StudentLesson
                             {
                                 Id = sl.Id,
                                 UserId = sl.UserId,
                                 PairId = sl.PairId,
                             };
                return result.ToList();
            }
        }

        public List<StudentLessonDto> GetByUserId(int userId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from sl in context.StudentLessons
                             join lapp in context.LessonAndPrelectorPairs
                             on sl.PairId equals lapp.Id
                             join l in context.Lessons
                             on lapp.LessonId equals l.Id
                             join pd in context.PrelectorDetails
                             on lapp.UserId equals pd.UserId
                             join pa in context.PrelectorAppellations
                             on pd.AppellationId equals pa.Id
                             where sl.UserId == userId
                             select new StudentLessonDto
                             {
                                 Id = sl.Id,
                                 StudentId = sl.UserId,
                                 LessonName = l.Name,
                                 LessonCode = l.Code,
                                 Period = l.Period,
                                 Credit= l.Credit,
                                 LessonHour = l.LessonHours,
                                 Capacity = l.Capacity,
                                 isImperative = l.isImperative,
                                 PrelectorId = pd.UserId,
                                 PrelectorName = pd.Name,
                                 PrelectorSurname = pd.Surname,
                                 PrelectorAppellation = pa.Appellation
                                 

                             };
                return result.ToList();
            }
        }

        public List<ProgramForStudentDto> GetProgramForStudent(int studentId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from sl in context.StudentLessons
                             join lapp in context.LessonAndPrelectorPairs
                             on sl.PairId equals lapp.Id
                             join l in context.Lessons
                             on lapp.LessonId equals l.Id
                             join pd in context.PrelectorDetails
                             on lapp.UserId equals pd.UserId
                             join pa in context.PrelectorAppellations
                             on pd.AppellationId equals pa.Id
                             join lacr in context.LessonsAtClassRooms
                             on lapp.Id equals lacr.LessonAndPrelectorPairId
                             join cr in context.ClassRooms
                             on lacr.ClassRoomId equals cr.Id
                             join wd in context.WeekDays
                             on lacr.LessonDay equals wd.Id
                             join lst in context.LessonStartTimes
                             on lacr.LessonStartTime equals lst.Id
                             where sl.UserId == studentId
                             select new ProgramForStudentDto
                             {
                                 Id = sl.Id,
                                 StudentId = sl.UserId,
                                 LessonName = l.Name,
                                 LessonCode = l.Code,
                                 PrelectorName = pd.Name,
                                 PrelectorSurname = pd.Surname,
                                 PrelectorAppellation = pa.Appellation,
                                 ClassRoomName = cr.RoomName,
                                 LessonDay = wd.DayName,
                                 LessonStartTime = lst.StartTime

                             };
                return result.ToList();
            }
        }
    }
}
