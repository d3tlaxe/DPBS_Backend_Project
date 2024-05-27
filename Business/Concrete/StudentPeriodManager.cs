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
    public class StudentPeriodManager : IStudentPeriodService
    {
        IStudentPeriodDal _studentPeriodDal;

        public StudentPeriodManager(IStudentPeriodDal studentPeriodDal)
        {
            _studentPeriodDal = studentPeriodDal;
        }

        public IResult Add(StudentPeriod studentPeriod)
        {
            _studentPeriodDal.Add(studentPeriod);
            return new SuccessResult(Messages.StudentPeriodAdded);
        }
    }
}
