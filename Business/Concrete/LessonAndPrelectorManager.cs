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
    public class LessonAndPrelectorManager : ILessonAndPrelectorPairService
    {

        ILessonAndPrelectorPairDal _LessonAndPrelectorPairDal;

        public LessonAndPrelectorManager(ILessonAndPrelectorPairDal lessonAndPrelectorPairDal)
        {
            _LessonAndPrelectorPairDal = lessonAndPrelectorPairDal;
        }

        public IResult Add(LessonAndPrelectorPair lessonAndPrelectorPair)
        {

            _LessonAndPrelectorPairDal.Add(lessonAndPrelectorPair);
            return new SuccessResult(Messages.lessonAndPrelectorPairAdded);

        }

        public IDataResult<List<PrelectorsOfLessonDto>> GetByLessonId(int lessonId)
        {
            return new SuccessDataResult<List<PrelectorsOfLessonDto>>(_LessonAndPrelectorPairDal.GetByLessonId(lessonId), Messages.LessonsPrelectorsListed);
        }

        public IDataResult<List<LessonsOfPrelectorDto>> GetByPrelectorId(int prelectorId)
        {
            return new SuccessDataResult<List<LessonsOfPrelectorDto>>(_LessonAndPrelectorPairDal.GetByPrelectorId(prelectorId), Messages.PrelectorsLessonsListed);
        }
    }
}
