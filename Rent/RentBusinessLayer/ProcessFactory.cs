using System;
using System.Collections.Generic;
using System.Text;

namespace RentBusinessLayer
{
    public class ProcessFactory
    {
        public static IClientProsess GetClientProsess()
        {
            return new ClientProcess();
        }
    }
}
