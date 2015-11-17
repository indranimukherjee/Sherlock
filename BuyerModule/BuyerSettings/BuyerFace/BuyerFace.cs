using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;

namespace BuyerModule.BuyerSettings.BuyerFace
{
    class BuyerFace : IBuyerFace
    {
       
        public int GenerateBuyerFace<T>(T buyer) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
