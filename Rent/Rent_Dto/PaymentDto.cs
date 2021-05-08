using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_Dto
{
    public class PaymentDto
    {
        public int PayID { get; set; }
        public int RentID { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
        public decimal Sum { get; set; }
        public bool Ontime { get; set; }
    }
}
