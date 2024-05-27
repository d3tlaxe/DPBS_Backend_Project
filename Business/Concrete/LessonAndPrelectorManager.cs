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

        ILessonAndPrelectorPairDal _lessonAndPrelectorPairDal;

        public LessonAndPrelectorManager(ILessonAndPrelectorPairDal lessonAndPrelectorPairDal)
        {
            _lessonAndPrelectorPairDal = lessonAndPrelectorPairDal;
        }

        public IResult Add(LessonAndPrelectorPair lessonAndPrelectorPair)
        {

            _lessonAndPrelectorPairDal.Add(lessonAndPrelectorPair);
            return new SuccessResult(Messages.lessonAndPrelectorPairAdded);

        }

        public IResult AddByParameter(int lessonId, int prelectorId)
        {
            if (isPairExist(lessonId,prelectorId).Data == false)
            {
                _lessonAndPrelectorPairDal.AddByParameter(lessonId, prelectorId);
                return new SuccessResult(Messages.lessonAndPrelectorPairAdded);
            }
            else
            {
                return new ErrorResult(Messages.ThereisAPair);
            }
            
        }

        public IDataResult<List<PrelectorsOfLessonDto>> GetByLessonId(int lessonId)
        {
            return new SuccessDataResult<List<PrelectorsOfLessonDto>>(_lessonAndPrelectorPairDal.GetByLessonId(lessonId), Messages.LessonsPrelectorsListed);
        }

        public IDataResult<List<LessonsOfPrelectorDto>> GetByPrelectorId(int prelectorId)
        {
            return new SuccessDataResult<List<LessonsOfPrelectorDto>>(_lessonAndPrelectorPairDal.GetByPrelectorId(prelectorId), Messages.PrelectorsLessonsListed);
        }


        public IDataResult<int> GetPairId(int lessonId, int prelectorId)
        {
            int pairId = 0;
            if (_lessonAndPrelectorPairDal.Get(lapp => lapp.LessonId == lessonId && lapp.UserId == prelectorId) != null)
            {
                pairId = _lessonAndPrelectorPairDal.Get(lapp => lapp.LessonId == lessonId && lapp.UserId == prelectorId).Id;
                return new SuccessDataResult<int>(pairId, "PairId Bulundu");
            }
            else
            {
                return new ErrorDataResult<int>(pairId, "Dersi seçen öğrenci bulunamadı");
            }
        }

        public IDataResult<bool> isPairExist(int lessonId, int prelectorId)
        {

            bool isPairExist;
            if (_lessonAndPrelectorPairDal.Get(lapp => lapp.LessonId == lessonId && lapp.UserId == prelectorId) != null)
            {
                isPairExist = true;
                return new ErrorDataResult<bool>(isPairExist, Messages.ThereisAPair);
            }
            else
            {
                isPairExist = false;
                return new SuccessDataResult<bool>(isPairExist, Messages.ThereisNotPair);
            }

        }
    }
}
