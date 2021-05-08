using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;


namespace RentBusinessLayer
{
    public interface IAgreementProcess
    {
        AgreementDto Get(int ID);
        void Add(AgreementDto agreement);
        void Update(AgreementDto agreement);
        public void Delete(int ID);

        IList<AgreementDto> getList();
    }
}
