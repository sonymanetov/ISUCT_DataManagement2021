using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;

namespace RentBusinessLayer
{
    public interface IHPProcess
    {
        IList<HPDto> getList(string Name);
    }
}
