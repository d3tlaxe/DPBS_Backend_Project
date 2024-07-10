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
    public interface ILessonsAtClassRoomService
    {
        IDataResult<bool> isClassRoomAvailable(int classRoomId, int lessonDay, int LessonStartTime);
        IDataResult<bool> isThereAnyLessonSameTime(int prelectorId, int lessonDay, int lessonStartTime);


        IResult Add(LessonAtClassRoom lessonAtClassRoom);

        IResult AddWithParameter(int classroomId, int lessonId, int prelectorId, int lessonDayId, int lessonStartTimeId);


        IDataResult<List<ProgramForPrelectorDto>> GetProgramForPrelector(int prelectorId);


        IDataResult<List<LessonAtClassRoom>> GetPlannedClassrooms();



        IDataResult<List<ProgramForPrelectorDto>> GetPlannedLesson();

        IDataResult<List<ProgramForPrelectorDto>> GetPlannedPrelector();

    }
}
