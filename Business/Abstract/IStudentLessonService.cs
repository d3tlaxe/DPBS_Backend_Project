using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentLessonService
    {

        IDataResult<List<StudentLessonDto>> GetByUserId(int userId);

        IDataResult<List<ProgramForStudentDto>> GetProgramForStudent(int studentId);

        IResult Add(int studentId, int lessonId, int prelectorId);
        IResult Update(StudentLesson studentLesson);

        IResult Delete(StudentLesson studentLesson);

        IDataResult<int> GetStudentCount(int lessonId, int prelectorId);

    }
}
