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
    }
}
