using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILessonsAtClassRoomDal : IEntityRepository<LessonAtClassRoom>
    {
        List<ProgramForPrelectorDto> GetProgramForPrelector(int prelectorId);

        List<LessonAtClassRoom> GetByPairId(int pairId);

        List<LessonAtClassRoom> GetPlannedClassrooms();





        List<ProgramForPrelectorDto> GetPlannedLesson();

        List<ProgramForPrelectorDto> GetPlannedPrelector();





    }
}
