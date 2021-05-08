using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;

namespace RentBusinessLayer
{
    public interface IPaymentProcess
    {
        PaymentDto Get(int PayID);
        void Add(PaymentDto payment);
        void Update(PaymentDto payment);
        public void Delete(int ID);

        IList<PaymentDto> getList();
    }
}
