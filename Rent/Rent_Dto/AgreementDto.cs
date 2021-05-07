using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_Dto
{
   public class AgreementDto
    {
        public int RentID { get; set; }
        public int RoomID { get; set; }
        public int ClientID { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public decimal Payday { get; set; }
    }
}
