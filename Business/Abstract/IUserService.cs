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
    public interface IUserService
    {
        IDataResult<User> LoginCheck(string eMail, string password);

        IDataResult<List<User>> GetAll();

        User GetByMail(string email);


        IDataResult<List<StudentDetailDto>> GetStudentDetails(int userId);
        IDataResult<List<PrelectorDetailDto>> GetPrelectorDetails(int userId);


        //Alttakilerden sadece add yazıldı 
        IResult Add(User user);
        //IResult Update(User user);
        //
        //IResult Delete(User user);







    }
}
