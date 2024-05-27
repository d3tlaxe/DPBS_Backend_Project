using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u=> u.EMail == email);
        }

        public IDataResult<List<StudentDetailDto>> GetStudentDetails(int userId)
        {
            return new SuccessDataResult<List<StudentDetailDto>>(_userDal.GetStudentDetails(userId));
        }


        public IDataResult<List<PrelectorDetailDto>> GetPrelectorDetails(int userId)
        {
            return new SuccessDataResult<List<PrelectorDetailDto>>(_userDal.GetPrelectorDetails(userId));
        }


        public IDataResult<User> LoginCheck(string eMail, string password)
        {
            if (_userDal.Get(u => u.EMail == eMail && u.Password == password) != null)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.EMail == eMail && u.Password == password));
            }
            else
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
    }
}
