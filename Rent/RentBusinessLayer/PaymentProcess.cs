using Rent_Dto;
using Rent.DataAcess;
using Rent.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentBusinessLayer
{
    public class PaymentProcess : IPaymentProcess
    {
        private readonly IPaymentDAO paymentDao;
        public PaymentProcess()
        {
            paymentDao = DAOFactory.getpaymentdao();
        }

        public PaymentDto Get(int ID)
        {
            return DtoConverter.Convert(paymentDao.Get(ID));
        }
        public void Add(PaymentDto payment)
        {
            paymentDao.Add(DtoConverter.Convert(payment));
        }

        public void Update(PaymentDto payment)
        {
            paymentDao.Update(DtoConverter.Convert(payment));
        }
        public void Delete(int ID)
        {
            paymentDao.Delete(ID);
        }

        public IList<PaymentDto> getList()
        {
            return DtoConverter.Convert(paymentDao.getList());
        }
    }
}
