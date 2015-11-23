using DataAccessLayer.EF;
using EntityDataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerModule.SaveBuyerInfo
{
    class Savebuyer : Isavebuyer
    {
      

        public T SaveLeadDetails<T>(T lead, int save = 0) where T : class
        {
            GenericRepository<T> gnr = new GenericRepository<T>(new EFDbContext());
            if (save == 0)
                gnr.Insert(lead);
            else if (save == 1)
                gnr.Update(lead);

            return lead;
        }
    }
}
