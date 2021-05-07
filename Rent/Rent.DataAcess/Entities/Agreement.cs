using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.DataAcess.Entities
{
    public class Agreement
    {
        public int RentID;
        public int RoomID;
        public int ClientID;
        public DateTime Start;
        public DateTime Finish;
        public decimal Payday;
    }
}
