using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;
using Rent.DataAcess;
using Rent.DataAcess.Entities;

namespace RentBusinessLayer
{
    public class AgreementProcess : IAgreementProcess
    {
        private readonly IAgreementDAO agreementDao;
        public AgreementProcess()
        {
            agreementDao = DAOFactory.getagreementdao();
        }

        public AgreementDto Get(int ID)
        {
            return DtoConverter.Convert(agreementDao.Get(ID));
        }
        public void Add(AgreementDto agreement)
        {
            agreementDao.Add(DtoConverter.Convert(agreement));
        }

        public void Update(AgreementDto agreement)
        {
            agreementDao.Update(DtoConverter.Convert(agreement));
        }
        public void Delete(int ID)
        {
            agreementDao.Delete(ID);
        }

        public IList<AgreementDto> getList()
        {
            return DtoConverter.Convert(agreementDao.getList());
        }
    }
}
