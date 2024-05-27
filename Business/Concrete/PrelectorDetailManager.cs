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
    public class PrelectorDetailManager : IPrelectorDetailService
    {

        IPrelectorDetailDal _prelectorDetailDal;
        IUserDal _userDal;

        public PrelectorDetailManager(IPrelectorDetailDal prelectorDetailDal, IUserDal userDal)
        {
            _prelectorDetailDal = prelectorDetailDal;
            _userDal = userDal;
        }


        public IResult Add(PrelectorForAddDto prelectorForAddDto)
        {
            User user = new User
            {
                EMail = prelectorForAddDto.Email,
                Password = prelectorForAddDto.Password,
                UserTypeId = 2
            };
            _userDal.Add(user);



            List<User> recievedUsers = _userDal.GetAll();
            int lastIndex = recievedUsers.Count - 1;
            int lastItemId = recievedUsers[lastIndex].Id;
            PrelectorDetail prelectorDetail = new PrelectorDetail
            {
                UserId = lastItemId,
                TCNo = prelectorForAddDto.TCNo,
                Name = prelectorForAddDto.Name,
                Surname = prelectorForAddDto.Surname,
                AppellationId = prelectorForAddDto.AppellationId,
                Phone = prelectorForAddDto.Phone,
                Address = prelectorForAddDto.Address
            };

            _prelectorDetailDal.Add(prelectorDetail);

            return new SuccessResult(Messages.PrelectorAdded);



        }

    }
}
