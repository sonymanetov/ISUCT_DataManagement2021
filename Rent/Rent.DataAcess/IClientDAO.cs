using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;


namespace Rent.DataAcess.Entities
{
   public interface IClientDAO
    {
        Client get(int ID);
        void add(Client client);
        void update(Client client);
        void delete(int ID);

        IList<Client> getList();

        IList<Client> SearchClient(string Name, string Bank, string Agent);
    }
}
