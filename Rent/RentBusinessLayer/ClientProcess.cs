using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;
using Rent.DataAcess;
using Rent.DataAcess.Entities;

namespace RentBusinessLayer
{
    public class ClientProcess : IClientProsess
    {
        private readonly IClientDAO clientDao;
        public ClientProcess()
        {
            clientDao = DAOFactory.getclientdao();
        }

      public  ClientDto get(int ID)
        {
            return DtoConverter.Convert(clientDao.get(ID));
        }
      public  void add(ClientDto client)
        {
            clientDao.add(DtoConverter.Convert(client));
        }
    
        public void update(ClientDto client)
        {
            clientDao.update(DtoConverter.Convert(client));
        }
        public void delete(int ID)
        {
            clientDao.delete(ID);
        }

        public IList<ClientDto> getList()
        {
           return DtoConverter.Convert(clientDao.getList());
        }
    }
}
