using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerModule.BuyerSettings.productMapping
{
    interface IBuyerMapp
    {
        //int BuyerProductMap<T>(T buyer) where T : class;
        int BuyerProductMap(t_buyer_master buyer_info);
    }
}
