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
    public class LessonsAtClassRoomManager : ILessonsAtClassRoomService
    {

        ILessonsAtClassRoomDal _lessonAtClassRoomDal;

        public LessonsAtClassRoomManager(ILessonsAtClassRoomDal lessonAtClassRoomDal)
        {
            _lessonAtClassRoomDal = lessonAtClassRoomDal;
        }

        public IResult Add(LessonAtClassRoom lessonAtClassRoom)
        {
            if (lessonAtClassRoom.LessonAndPrelectorPairId != 0)
            {
                _lessonAtClassRoomDal.Add(lessonAtClassRoom);
                return new SuccessResult(Messages.LessonAtClassRoomAdded);
            }
            else
            {
                return new ErrorResult(Messages.IdCantZero);
            }
        }

        public IDataResult<bool> isClassRoomAvailable(int classRoomId, int lessonDay, int LessonStartTime)
        {
            bool isAvailable;
            if (_lessonAtClassRoomDal.Get(lacr => lacr.ClassRoomId == classRoomId && lacr.LessonDay == lessonDay && lacr.LessonStartTime == LessonStartTime) != null)
            {
                isAvailable = false;
                return new ErrorDataResult<bool>(isAvailable, Messages.ClassRoomisNotAvailable);
            }
            else
            {
                isAvailable=true;
                return new SuccessDataResult<bool>(isAvailable, Messages.ClassRoomisAvailable);
            }
        }
    }
}
