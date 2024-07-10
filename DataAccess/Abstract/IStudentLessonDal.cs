using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStudentLessonDal : IEntityRepository<StudentLesson>
    {
        List<StudentLessonDto> GetByUserId(int userId);
        List<ProgramForStudentDto> GetProgramForStudent(int studentId);

        List<StudentLesson> GetByPairId(int pairId);

       


    }
}
