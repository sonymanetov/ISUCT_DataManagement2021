using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;

namespace RentBusinessLayer
{
    public interface IClientProsess 
    {
        ClientDto get(int ID);
        void add(ClientDto client);
        void update(ClientDto client);
        void delete(int ID);

        IList<ClientDto> getList();

    }
}
