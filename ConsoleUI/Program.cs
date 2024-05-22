using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User yeni = new User { Id = 1, EMail = "deneme", Password = "ahaha", UserTypeId = 1 };

            UserManager userManager = new UserManager(new EfUserDal());

            User gelenUser = userManager.LoginCheck("ali", "veli").Data;





            Console.WriteLine(gelenUser.UserTypeId + "   " +gelenUser.EMail);
        }
    }
}