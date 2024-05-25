using Business.Abstract;
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

        public StudentLessonManager(IStudentLessonDal studentLessonDal)
        {
            _studentLessonDal = studentLessonDal;
        }

        public IResult Add(StudentLesson studentLesson)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(StudentLesson studentLesson)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<StudentLessonDto>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<StudentLessonDto>>(_studentLessonDal.GetByUserId(userId), "Öğrencinin Dersleri Listelendi");
        }

        public IResult Update(StudentLesson studentLesson)
        {
            throw new NotImplementedException();
        }
    }
}
