using Core.DataAccess.EntityFramework;
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
    public class EfLessonsAtClassRoomDal : EfEntityRepositoryBase<LessonAtClassRoom, MyContext>, ILessonsAtClassRoomDal
    {
        public List<LessonAtClassRoom> GetByPairId(int pairId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from lacr in context.LessonsAtClassRooms
                             where lacr.LessonAndPrelectorPairId == pairId
                             select new LessonAtClassRoom
                             {
                                 Id = lacr.Id,
                                 ClassRoomId = lacr.ClassRoomId,
                                 LessonAndPrelectorPairId = lacr.LessonAndPrelectorPairId,
                                 LessonDay = lacr.LessonDay,
                                 LessonStartTime = lacr.LessonStartTime

                             };
                return result.ToList();
            }
        }

        public List<ProgramForPrelectorDto> GetProgramForPrelector(int prelectorId)
        {
            using (MyContext context = new MyContext())
            {
                var result = from lacr in context.LessonsAtClassRooms
                             join lapp in context.LessonAndPrelectorPairs
                             on lacr.LessonAndPrelectorPairId equals lapp.Id
                             join l in context.Lessons
                             on lapp.LessonId equals l.Id
                             join cr in context.ClassRooms
                             on lacr.ClassRoomId equals cr.Id
                             join wd in context.WeekDays
                             on lacr.LessonDay equals wd.Id
                             join lst in context.LessonStartTimes
                             on lacr.LessonStartTime equals lst.Id
                             where lapp.UserId == prelectorId
                             select new ProgramForPrelectorDto
                             {
                                 Id = lacr.Id,
                                 PrelectorId = lapp.UserId,
                                 LessonName = l.Name,
                                 LessonCode = l.Code,
                                 ClassRoomName = cr.RoomName,
                                 LessonDayId = wd.Id,
                                 LessonDay = wd.DayName,
                                 LessonHourId = lst.Id,
                                 LessonStartTime = lst.StartTime

                             };
                return result.ToList();
            }
        }



        public List<LessonAtClassRoom> GetPlannedClassrooms()
        {
            using (MyContext context = new MyContext())
            {
                var result = (from lacr in context.LessonsAtClassRooms
                             select new LessonAtClassRoom
                             {
                                 
                                 ClassRoomId = lacr.ClassRoomId,


                             }).Distinct();
                return result.ToList();
            }
        }





        public List<ProgramForPrelectorDto> GetPlannedLesson()
        {
            using (MyContext context = new MyContext())
            {
                var result = (from lacr in context.LessonsAtClassRooms
                             join lapp in context.LessonAndPrelectorPairs
                             on lacr.LessonAndPrelectorPairId equals lapp.Id
                             join l in context.Lessons
                             on lapp.LessonId equals l.Id
                             join cr in context.ClassRooms
                             on lacr.ClassRoomId equals cr.Id
                             join wd in context.WeekDays
                             on lacr.LessonDay equals wd.Id
                             join lst in context.LessonStartTimes
                             on lacr.LessonStartTime equals lst.Id
                             select new ProgramForPrelectorDto
                             {
                                 LessonName = l.Name

                             }).Distinct();
                return result.ToList();
            }
        }


        public List<ProgramForPrelectorDto> GetPlannedPrelector()
        {
            using (MyContext context = new MyContext())
            {
                var result = (from lacr in context.LessonsAtClassRooms
                              join lapp in context.LessonAndPrelectorPairs
                              on lacr.LessonAndPrelectorPairId equals lapp.Id
                              join l in context.Lessons
                              on lapp.LessonId equals l.Id
                              join cr in context.ClassRooms
                              on lacr.ClassRoomId equals cr.Id
                              join wd in context.WeekDays
                              on lacr.LessonDay equals wd.Id
                              join lst in context.LessonStartTimes
                              on lacr.LessonStartTime equals lst.Id
                              select new ProgramForPrelectorDto
                              {
                                  PrelectorId = lapp.UserId

                              }).Distinct();
                return result.ToList();
            }
        }


















    }
}
