using System;
using System.Collections.Generic;
using System.Text;
using Rent_Dto;
using Rent.DataAcess;
using Rent.DataAcess.Entities;

namespace RentBusinessLayer
{
    public class HPProcess : IHPProcess
    {
        private readonly IHPDAO hpDao;
        public HPProcess()
        {
            hpDao = DAOFactory.gethpdao();
        }
        public IList<HPDto> getList(string name)
        {
            return DtoConverter.Convert(hpDao.getList(name));
        }
    }
}
