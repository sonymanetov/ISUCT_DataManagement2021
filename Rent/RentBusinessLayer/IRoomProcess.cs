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
        IList<RoomDto> SearchRoom(int RoomID, decimal Area, decimal Cost1, decimal Cost2);

    }
}
