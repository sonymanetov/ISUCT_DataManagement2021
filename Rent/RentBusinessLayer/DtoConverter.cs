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
    }
}
