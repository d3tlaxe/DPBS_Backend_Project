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
    public interface ILessonService
    {
        IDataResult<List<Lesson>> GetAll();
        IDataResult<List<Lesson>> GetByPeriod(int period);
        IDataResult<Lesson> GetByName(string name);
        IDataResult<Lesson> GetById(int lessonId);
        IDataResult<List<Lesson>> GetByImperative(bool isImprerative);
        IDataResult<List<Lesson>> GetHighClassLessons(int myPeriod);

        IResult Add(LessonForAddDto lessonForAddDto);
        IResult Update(Lesson lesson);

        IResult Delete(Lesson lesson);  // Bu denenmedi
        

    }
}
