using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
