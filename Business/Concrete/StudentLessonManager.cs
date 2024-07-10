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


        public bool isExistingLesson(List<StudentLessonDto> studentLessons, int lessonId)
        {
            bool isExisting = false;
            for (int i = 0; i < studentLessons.Count; i++)
            {
                if(studentLessons[i].LessonId == lessonId)
                {
                    isExisting = true;
                }
            }
            return isExisting;
        }




        public IResult Add(int studentId, int lessonId, int prelectorId)
        {

            List<StudentLessonDto> studentLessons = _studentLessonDal.GetByUserId(studentId);
            int pairId;
            StudentLesson studentLesson;
            if (isExistingLesson(studentLessons, lessonId) == false) 
            {
                pairId = _lessonAndPrelectorPairDal.Get(lapp => lapp.LessonId == lessonId && lapp.UserId == prelectorId).Id;
                studentLesson = new StudentLesson
                {
                    UserId = studentId,
                    PairId = pairId
                };
                _studentLessonDal.Add(studentLesson);
                return new SuccessResult(Messages.StudentLessonAdded);
            }
            else
            {
                return new SuccessResult("Bu Ders Zaten Seçildi. Lütfen Diğer Dersler İçin Seçim Yapınız");
            }
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
