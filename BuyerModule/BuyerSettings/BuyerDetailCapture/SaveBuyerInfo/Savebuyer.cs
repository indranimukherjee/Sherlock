using DataAccessLayer.EF;
using DataAccessLayer.EF.Model.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerModule.BuyerSettings.BuyerDetailCapture.SaveBuyerInfo
{
    class Savebuyer : Isavebuyer
    {
        public int SaveBuyerDetails<T>(T buyer) where T : class
        {
            GenericRepository<T> gnr = new GenericRepository<T>(new SherlockdbEntities());
            gnr.Insert(buyer);

            return 0;
        }
    }
}
