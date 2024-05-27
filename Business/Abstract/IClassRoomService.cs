using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClassRoomService
    {

        IDataResult<List<ClassRoom>> GetAll();
        IDataResult<List<ClassRoom>> GetBiggerThanParameter(int capacity);
        IDataResult<ClassRoom> GetByName(string name);
        IResult Add(ClassRoom classRoom);
        IResult Update(ClassRoom classRoom);
        IResult Delete(ClassRoom classRoom);  // Bu denenmedi


    }
}
