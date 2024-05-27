using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentDetailManager : IStudentDetailService
    {
        IStudentDetailDal _studentDetailDal;
        IUserDal _userDal;
        IStudentPeriodDal _studentPeriodDal;

        public StudentDetailManager(IStudentDetailDal studentDetailDal, IUserDal userDal, IStudentPeriodDal studentPeriodDal)
        {
            _studentDetailDal = studentDetailDal;
            _userDal = userDal;
            _studentPeriodDal = studentPeriodDal;
        }

        public IResult Add(StudentForAddDto studentForAddDto)
        {
            User user = new User
            {
                EMail = studentForAddDto.Email,
                Password = studentForAddDto.Password,
                UserTypeId = 3
            };
            _userDal.Add(user);



            List<User> recievedUsers = _userDal.GetAll();
            int lastIndex = recievedUsers.Count - 1;
            int lastItemId = recievedUsers[lastIndex].Id;
            StudentDetail studentDetail = new StudentDetail
            {
                UserId = lastItemId,
                TCNo = studentForAddDto.TCNo,
                Name = studentForAddDto.Name,
                Surname = studentForAddDto.Surname,
                Phone = studentForAddDto.Phone,
                Address = studentForAddDto.Address,
            };

            

            _studentDetailDal.Add(studentDetail);

            StudentPeriod studentPeriod = new StudentPeriod { UserId = lastItemId, Period = 1 };
            _studentPeriodDal.Add(studentPeriod);

            return new SuccessResult(Messages.StudentAdded);


        }
    }
}
