using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LessonManager : ILessonService
    {

        ILessonDal _lessonDal;
        ILessonAndPrelectorPairDal _lessonAndPrelectorPairDal;

        public LessonManager(ILessonDal lessonDal, ILessonAndPrelectorPairDal lessonAndPrelectorPairDal)
        {
            _lessonDal = lessonDal;
            _lessonAndPrelectorPairDal = lessonAndPrelectorPairDal;
        }

        public IResult Add(LessonForAddDto lessonForAddDto)
        {
            Lesson lesson = new Lesson
            {
                Name = lessonForAddDto.Name,
                Code = lessonForAddDto.Code,
                Period = lessonForAddDto.Period,
                Credit = lessonForAddDto.Credit,
                LessonHours = lessonForAddDto.LessonHours,
                Capacity = lessonForAddDto.Capacity,
                isImperative = lessonForAddDto.isImperative
            };
            _lessonDal.Add(lesson);


            List<Lesson> recievedLessons = _lessonDal.GetAll();
            int lastIndex = recievedLessons.Count - 1;
            int lastItemId = recievedLessons[lastIndex].Id;
            LessonAndPrelectorPair lessonAndPrelectorPair = new LessonAndPrelectorPair
            {
                LessonId = lastItemId,
                UserId = lessonForAddDto.PrelectorId,
            };

            _lessonAndPrelectorPairDal.Add(lessonAndPrelectorPair);

            return new SuccessResult(Messages.LessonAdded);
        }

        public IResult Delete(Lesson lesson)
        {
            _lessonDal.Delete(lesson);
            return new SuccessResult(Messages.LessonDeleted);
        }

        public IDataResult<List<Lesson>> GetAll()
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(), Messages.LessonListed);
        }

        public IDataResult<Lesson> GetById(int lessonId)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(l => l.Id == lessonId));
        }

        public IDataResult<List<Lesson>> GetByImperative(bool isImperative)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetByImperative(isImperative));
        }


        public IDataResult<List<Lesson>> GetHighClassLessons(int myPeriod)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetHighClassLessons(myPeriod));
        }

        public IDataResult<Lesson> GetByName(string name)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(l => l.Name == name));
        }

        public IDataResult<List<Lesson>> GetByPeriod(int period)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(l => l.Period == period));
        }

        public IResult Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
            return new SuccessResult(Messages.LessonUpdated);
        }
    }
}
