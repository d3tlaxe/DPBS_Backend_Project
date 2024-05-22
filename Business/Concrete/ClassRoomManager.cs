using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClassRoomManager : IClassRoomService
    {

        IClassRoomDal _classRoomDal;

        public ClassRoomManager(IClassRoomDal classRoomDal)
        {
            _classRoomDal = classRoomDal;    
        }




        public IResult Add(ClassRoom classRoom)
        {
            _classRoomDal.Add(classRoom);
            return new SuccessResult(Messages.ClassRoomAdded);
        }

        public IResult Delete(ClassRoom classRoom)
        {
            _classRoomDal.Delete(classRoom);
            return new SuccessResult(Messages.ClassRoomDeleted);
        }

        public IDataResult<List<ClassRoom>> GetAll()
        {
            return new SuccessDataResult<List<ClassRoom>>(_classRoomDal.GetAll(), Messages.ClassRoomsListed);
        }

        public IDataResult<List<ClassRoom>> GetBiggerThanParameter(int capacity)
        {
            return new SuccessDataResult<List<ClassRoom>>(_classRoomDal.GetBiggerThanParameter(capacity));
        }

        public IDataResult<ClassRoom> GetByName(string name)
        {
            return new SuccessDataResult<ClassRoom>(_classRoomDal.Get(c => c.RoomName == name));
        }

        public IResult Update(ClassRoom classRoom)
        {
            _classRoomDal.Update(classRoom);
            return new SuccessResult(Messages.ClassRoomUpdated);
        }
    }
}
