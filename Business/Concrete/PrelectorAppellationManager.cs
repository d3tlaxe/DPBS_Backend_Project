using Business.Abstract;
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
    public class PrelectorAppellationManager : IPrelectorAppellationService
    {
        IPrelectorAppellationDal _prelectorAppellationDal;

        public PrelectorAppellationManager(IPrelectorAppellationDal prelectorAppellationDal)
        {
            _prelectorAppellationDal = prelectorAppellationDal;
        }

        public IDataResult<List<PrelectorAppellation>> GetAll()
        {
            return new SuccessDataResult<List<PrelectorAppellation>>(_prelectorAppellationDal.GetAll(), "Öğretim Görevlisi Unvanları Listelendi");
        }
    }
}
