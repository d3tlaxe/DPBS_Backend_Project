using Core.DataAccess;
using Core.Utilities.Results;
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
    public interface ILessonDal : IEntityRepository<Lesson>
    {
        List<Lesson> GetByImperative(bool isImperative);
        List<Lesson> GetHighClassLessons(int myPeriod);

    }
}
