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
    public interface ILessonAndPrelectorPairDal : IEntityRepository<LessonAndPrelectorPair>
    {
        List<LessonsOfPrelectorDto> GetByPrelectorId(int prelectorId);
        List<PrelectorsOfLessonDto> GetByLessonId(int lessonId);
    }
}
