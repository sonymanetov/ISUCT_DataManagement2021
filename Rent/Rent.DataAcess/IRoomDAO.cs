using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;

namespace Rent.DataAcess
{
    public interface IRoomDAO
    {
        Room Get(int ID);
        void Add(Room room);
        void Update(Room room);
        public void Delete(int ID);

        IList<Room> getList();
    }
}
