using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;
using Rent.DataAcess;
using Rent.DataAcess.Entities;

namespace RentBusinessLayer
{
    public class ClientProcess
    {
        private readonly IClientDAO clientDao;
        public ClientProcess()
        {
            clientDao = DAOFactory.getclientdao();
        }

        ClientDto get(int ID)
        {
            return DtoConverter.Convert(clientDao.get(ID));
        }
        void add(ClientDto client)
        {
            clientDao.add(DtoConverter.Convert(client));
        }
    
        void update(ClientDto client)
        {
            clientDao.update(DtoConverter.Convert(client));
        }
        void delete(int ID)
        {
            clientDao.delete(ID);
        }

        IList<ClientDto> getList()
        {
           return DtoConverter.Convert(clientDao.getList());
        }
    }
}
