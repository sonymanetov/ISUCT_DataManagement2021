using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;

namespace Rent.DataAcess
{
    public class DAOFactory
    {
        public static IClientDAO getclientdao()
        {
            return new ClientDAO();
        }
        public static IRoomDAO getroomdao()
        {
            return new RoomDAO();
        }
        public static IAgreementDAO getagreementdao()
        {
            return new AgreementDAO();
        }
    }
}
