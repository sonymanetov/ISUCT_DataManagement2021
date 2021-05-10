using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;
using Rent_Dto;

namespace RentBusinessLayer
{
    public class DtoConverter
    {
        public static Client Convert(ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }
            Client client = new Client();
            client.ClientID = clientDto.ClientID;
            client.Name = clientDto.Name;
            client.BankDetails = clientDto.BankDetails;
            client.Adress = clientDto.Adress;
            client.Phone = clientDto.Phone;
            client.AgentName = clientDto.AgentName;
            return client;
        }

        public static ClientDto Convert(Client client)
        {
            if (client == null)
            {
                return null;
            }
            ClientDto clientDto = new ClientDto();
            clientDto.ClientID = client.ClientID;
            clientDto.Name = client.Name;
            clientDto.BankDetails = client.BankDetails;
            clientDto.Adress = client.Adress;
            clientDto.Phone = client.Phone;
            clientDto.AgentName = client.AgentName;
            return clientDto;
        }

        public static IList<ClientDto> Convert(IList<Client> client)
        {
            if (client == null)
            {
                return null;
            }
            IList<ClientDto> clientDto = new List<ClientDto>();
            foreach (var item in client )
            {
                clientDto.Add(Convert(item));
            }
            return clientDto;
        }

        public static Room Convert(RoomDto roomDto)
        {
            if (roomDto == null)
            {
                return null;
            }
            Room room = new Room();
            room.RoomID = roomDto.RoomID;
            room.Floor = roomDto.Floor;
            room.Area = roomDto.Area;
            room.Conditioner = roomDto.Conditioner;
            room.RentCostPerDay = roomDto.RentCostPerDay;
            return room;
        }

        public static RoomDto Convert(Room room)
        {
            if (room == null)
            {
                return null;
            }
            RoomDto roomDto = new RoomDto();
            roomDto.RoomID = room.RoomID;
            roomDto.Floor = room.Floor;
            roomDto.Area = room.Area;
            roomDto.Conditioner = room.Conditioner;
            roomDto.RentCostPerDay = room.RentCostPerDay;
            return roomDto;
        }

        public static IList<RoomDto> Convert(IList<Room> room)
        {
            if (room == null)
            {
                return null;
            }
            IList<RoomDto> roomDto = new List<RoomDto>();
            foreach (var item in room)
            {
                roomDto.Add(Convert(item));
            }
            return roomDto;
        }

        public static Agreement Convert(AgreementDto agreementDto)
        {
            if (agreementDto == null)
            {
                return null;
            }
            Agreement agreement = new Agreement();
            agreement.RentID = agreementDto.RentID;
            agreement.ClientID = agreementDto.ClientID;
            agreement.RoomID = agreementDto.RoomID;
            agreement.Start = agreementDto.Start;
            agreement.Finish = agreementDto.Finish;
            agreement.Payday = agreementDto.Payday;

            return agreement;
        }

        public static AgreementDto Convert(Agreement agreement)
        {
            if (agreement == null)
            {
                return null;
            }
            AgreementDto agreementDto = new AgreementDto();
            agreementDto.RentID = agreement.RentID;
            agreementDto.ClientID = agreement.ClientID;
            agreementDto.RoomID = agreement.RoomID;
            agreementDto.Start = agreement.Start;
            agreementDto.Finish = agreement.Finish;
            agreementDto.Payday = agreement.Payday;

            return agreementDto;
        }

        public static IList<AgreementDto> Convert(IList<Agreement> agreement)
        {
            if (agreement == null)
            {
                return null;
            }
            IList<AgreementDto> agreementDto = new List<AgreementDto>();
            foreach (var item in agreement)
            {
                agreementDto.Add(Convert(item));
            }
            return agreementDto;
        }

        public static Payment Convert(PaymentDto paymentDto)
        {
            if (paymentDto == null)
            {
                return null;
            }
            Payment payment = new Payment();
            payment.PayID = paymentDto.PayID;
            payment.RentID = paymentDto.RentID;
            payment.Date = paymentDto.Date;
            payment.Month = paymentDto.Month;
            payment.Sum = paymentDto.Sum;
            payment.Ontime = paymentDto.Ontime;

            return payment;
        }

        public static PaymentDto Convert(Payment payment)
        {
            if (payment == null)
            {
                return null;
            }
            PaymentDto paymentDto = new PaymentDto();
            paymentDto.PayID = payment.PayID;
            paymentDto.RentID = payment.RentID;
            paymentDto.Date = payment.Date;
            paymentDto.Month = payment.Month;
            paymentDto.Sum = payment.Sum;
            paymentDto.Ontime = payment.Ontime;

            return paymentDto;
        }

        public static IList<PaymentDto> Convert(IList<Payment> payment)
        {
            if (payment == null)
            {
                return null;
            }
            IList<PaymentDto> paymentDto = new List<PaymentDto>();
            foreach (var item in payment)
            {
                paymentDto.Add(Convert(item));
            }
            return paymentDto;
        }
        public static HP Convert(HPDto hpDto)
        {
            if (hpDto == null)
            {
                return null;
            }
            HP hp = new HP();
            hp.finish = hpDto.Finish;
     
            return hp;
        }

        public static HPDto Convert(HP hp)
        {
            if (hp == null)
            {
                return null;
            }
            HPDto hpDto = new HPDto();
            hpDto.Finish = hp.finish;

            return hpDto;
        }

        public static IList<HPDto> Convert(IList<HP> hp)
        {
            if (hp == null)
            {
                return null;
            }
            IList<HPDto> hpDto = new List<HPDto>();
            foreach (var item in hp)
            {
                hpDto.Add(Convert(item));
            }
            return hpDto;
        }
    }
}
