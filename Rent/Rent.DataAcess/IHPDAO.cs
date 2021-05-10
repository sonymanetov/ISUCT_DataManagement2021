using System;
using System.Collections.Generic;
using System.Text;
using Rent.DataAcess.Entities;

namespace Rent.DataAcess
{
    public interface IHPDAO
    {
        IList<HP> getList(string Name);
    }
}
