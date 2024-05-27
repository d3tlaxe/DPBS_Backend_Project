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
    public interface ILessonAndPrelectorPairService
    {
        IDataResult<List<LessonsOfPrelectorDto>> GetByPrelectorId(int prelectorId);

        IDataResult<List<PrelectorsOfLessonDto>> GetByLessonId(int lessonId);

        //IResult Add(LessonAndPrelectorPair lessonAndPrelectorPair);
        IResult AddByParameter(int lessonId, int prelectorId);
        IDataResult<bool> isPairExist(int lessonId, int prelectorId);

        IDataResult<int> GetPairId(int lessonId, int prelectorId);

    }
}
