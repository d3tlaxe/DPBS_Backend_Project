using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WeekDayManager : IWeekDayService
    {
        IWeekDayDal _weekDayDal;

        public WeekDayManager(IWeekDayDal weekDayDal)
        {
            _weekDayDal = weekDayDal;
        }

        public IDataResult<List<WeekDay>> GetAll()
        {
            return new SuccessDataResult<List<WeekDay>>(_weekDayDal.GetAll(), Messages.WeekDayListed);
        }
    }
}
