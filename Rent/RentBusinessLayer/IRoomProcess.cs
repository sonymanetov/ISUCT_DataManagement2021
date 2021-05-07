using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;

namespace RentBusinessLayer
{
    public interface IRoomProcess
    {
        RoomDto Get(int ID);
        void Add(RoomDto room);
        void Update(RoomDto room);
        void Delete(int ID);

        IList<RoomDto> getList();

    }
}
