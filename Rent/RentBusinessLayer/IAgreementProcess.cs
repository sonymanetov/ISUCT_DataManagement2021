using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;

namespace RentBusinessLayer
{
    public interface IAgreementProcess
    {
        Agreement Get(int ID);
        void Add(Agreement agreement);
        void Update(Agreement agreement);
        public void Delete(int ID);

        IList<Agreement> getList();
    }
}
