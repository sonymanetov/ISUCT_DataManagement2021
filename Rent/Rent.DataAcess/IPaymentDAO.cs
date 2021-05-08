using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;

namespace Rent.DataAcess
{
    public interface IPaymentDAO
    {
        Payment Get(int PayID);
        void Add(Payment payment);
        void Update(Payment payment);
        public void Delete(int ID);

        IList<Payment> getList();
    }
}
