using System;
using System.Collections.Generic;
using System.Text;

namespace RentBusinessLayer
{
    public class ProcessFactory
    {
        public static IClientProsess GetClientProsess()
        {
            return new ClientProcess();
        }

        public static IRoomProcess GetRoomProcess()
        {
            return new RoomProcess(); 
        }
        public static IAgreementProcess GetAgreementProcess()
        {
            return new AgreementProcess();
        }
        public static IPaymentProcess GetPaymentProcess()
        {
            return new PaymentProcess();
        }
    }
}
