using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_Dto
{
    public class RoomDto
    {
        public int RoomID { get; set; }
        public decimal Floor { get; set; }
        public decimal Area { get; set; }
        public bool Conditioner { get; set; }
        public decimal RentCostPerDay { get; set; }
    }
}
