using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Rent.DataAcess.Entities
{
    public class Room
    {
        public int RoomID;
        public decimal Floor;
        public decimal Area;
        public bool Conditioner;
        public decimal RentCostPerDay;
    }
}
