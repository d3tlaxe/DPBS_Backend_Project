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
        
        IResult Add(StudentLesson studentLesson);
        IResult Update(StudentLesson studentLesson);

        IResult Delete(StudentLesson studentLesson);  // Bu denenmedi
    }
}
