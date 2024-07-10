using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DashBoardManager : IDashBoardService
    {
        IPrelectorDetailDal _prelectorDetailDal;
        ILessonDal _lessonDal;
        IClassRoomDal _classRoomDal;
        IStudentDetailDal _studentDetailDal;

        ILessonsAtClassRoomDal _lessonAtClassRoomDal;

        public DashBoardManager(IPrelectorDetailDal prelectorDetailDal, ILessonDal lessonDal, IClassRoomDal classRoomDal, IStudentDetailDal studentDetailDal, ILessonsAtClassRoomDal lessonAtClassRoomDal)
        {
            _prelectorDetailDal = prelectorDetailDal;
            _lessonDal = lessonDal;
            _classRoomDal = classRoomDal;
            _studentDetailDal = studentDetailDal;
            _lessonAtClassRoomDal = lessonAtClassRoomDal;
        }



        public IDataResult<DashBoardDto> GetDashBoard()
        {
            int prelectorCount = _prelectorDetailDal.GetAll().Count();
            int lessonCount = _lessonDal.GetAll().Count();
            int classRoomCount = _classRoomDal.GetAll().Count();
            int studentCount = _studentDetailDal.GetAll().Count();


            int plannedLesson = Convert.ToInt32((_lessonAtClassRoomDal.GetPlannedLesson().Count() * 100) / lessonCount);
            int plannedClassroom = Convert.ToInt32((_lessonAtClassRoomDal.GetPlannedClassrooms().Count() * 100) / classRoomCount);
            int plannedPrelector = Convert.ToInt32((_lessonAtClassRoomDal.GetPlannedPrelector().Count() * 100) / prelectorCount);

            DashBoardDto dashBoard = new DashBoardDto()
            {
                ClassRoomCount = classRoomCount,
                StudentCount = studentCount,
                LessonCount = lessonCount,
                PrelectorCount = prelectorCount,
                PlannedLessonCount = plannedLesson,
                PlannedClassromCount = plannedClassroom,
                PlannedPrelectorCount = plannedPrelector
            };


            return new SuccessDataResult<DashBoardDto>(dashBoard, "DashBoard Gönderildi");
        }
    }
}
