using Rent_Dto;
using Rent.DataAcess;
using Rent.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentBusinessLayer
{
    public class RoomProcess : IRoomProcess
    {
        private readonly IRoomDAO roomDao;
        public RoomProcess()
        {
            roomDao = DAOFactory.getroomdao();
        }

        public RoomDto Get(int ID)
        {
            return DtoConverter.Convert(roomDao.Get(ID)); 
        }
        public void Add(RoomDto room)
        {
            roomDao.Add(DtoConverter.Convert(room));
        }

        public void Update(RoomDto room)
        {
            roomDao.Update(DtoConverter.Convert(room));
        }
        public void Delete(int ID)
        {
            roomDao.Delete(ID);
        }

        public IList<RoomDto> getList()
        {
            return DtoConverter.Convert(roomDao.getList());
        }
        public IList<RoomDto> SearchRoom(int RoomID, decimal Area, decimal Cost1, decimal Cost2)
        {
            return DtoConverter.Convert(roomDao.SearchRoom(RoomID, Area, Cost1, Cost2));
        }
    }
}
