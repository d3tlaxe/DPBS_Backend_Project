using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LessonStartTimeManager : ILessonStartTimeService
    {
        ILessonStartTimeDal _lessonStartTimeDal;

        public LessonStartTimeManager(ILessonStartTimeDal lessonStartTimeDal)
        {
            _lessonStartTimeDal = lessonStartTimeDal;
        }

        public IDataResult<List<LessonStartTime>> GetAll()
        {
            return new SuccessDataResult<List<LessonStartTime>>(_lessonStartTimeDal.GetAll(), Messages.LessonStartTimeListed);
        }
    }
}
