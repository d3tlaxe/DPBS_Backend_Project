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
    public class StudentLessonManager : IStudentLessonService
    {

        IStudentLessonDal _studentLessonDal;
        ILessonAndPrelectorPairDal _lessonAndPrelectorPairDal;

        public StudentLessonManager(IStudentLessonDal studentLessonDal, ILessonAndPrelectorPairDal lessonAndPrelectorPairDal)
        {
            _studentLessonDal = studentLessonDal;
            _lessonAndPrelectorPairDal = lessonAndPrelectorPairDal;
        }
        /*
        public IResult Add(StudentLesson studentLesson)
        {
            _studentLessonDal.Add(studentLesson);
            return new SuccessResult(Messages.studentLessonAdded);
        }
        */

        public IResult Add(int studentId, int lessonId, int prelectorId)
        {

            LessonAndPrelectorPair pair = new LessonAndPrelectorPair { LessonId = lessonId, UserId = prelectorId };
            _lessonAndPrelectorPairDal.AddByParameter(lessonId,prelectorId);


            List<LessonAndPrelectorPair> recievedPairs = _lessonAndPrelectorPairDal.GetAll();
            int lastIndex = recievedPairs.Count - 1;
            int lastItemId = recievedPairs[lastIndex].Id;
            StudentLesson studentLesson = new StudentLesson
            {
                UserId = studentId,
                PairId = lastItemId
            };

            _studentLessonDal.Add(studentLesson);

            return new SuccessResult(Messages.StudentLessonAdded);
        }

        public IResult Delete(StudentLesson studentLesson)
        {
            _studentLessonDal.Delete(studentLesson);
            return new SuccessResult(Messages.studentLessonDeleted);
        }

        public IDataResult<List<StudentLessonDto>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<StudentLessonDto>>(_studentLessonDal.GetByUserId(userId), "Öğrencinin Dersleri Listelendi");
        }

        public IDataResult<List<ProgramForStudentDto>> GetProgramForStudent(int studentId)
        {
            return new SuccessDataResult<List<ProgramForStudentDto>>(_studentLessonDal.GetProgramForStudent(studentId), Messages.StudentProgramListed);
        }

        public IDataResult<int> GetStudentCount(int lessonId, int prelectorId)
        {
            int pairId = 0;
            if (_lessonAndPrelectorPairDal.Get(lapp => lapp.LessonId == lessonId && lapp.UserId == prelectorId) != null)
            {
                pairId = _lessonAndPrelectorPairDal.Get(lapp => lapp.LessonId == lessonId && lapp.UserId == prelectorId).Id;
                return new SuccessDataResult<int>(_studentLessonDal.GetByPairId(pairId).Count, Messages.StudentCountShowed);
            }
            else
            {
                return new ErrorDataResult<int>(_studentLessonDal.GetByPairId(pairId).Count, "Ders ve Öğretim Görevlisi Çifti Bulunamadı");
            }
            
           
        }

        public IResult Update(StudentLesson studentLesson)
        {
            _studentLessonDal.Update(studentLesson);
            return new SuccessResult(Messages.studentLessonUpdated);
        }
    }
}
