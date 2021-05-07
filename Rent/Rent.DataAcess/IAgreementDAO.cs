using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;

namespace Rent.DataAcess
{
    public interface IAgreementDAO
    {
        Agreement Get(int ID);
        void Add(Agreement agreement);
        void Update(Agreement agreement);
        public void Delete(int ID);

        IList<Agreement> getList();
    }
}
