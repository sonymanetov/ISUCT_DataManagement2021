using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.DataAcess.Entities
{
    public class Payment
    {
        public int PayID;
        public int RentID;
        public DateTime Date;
        public int Month;
        public decimal Sum;
        public bool Ontime;
    }
}
