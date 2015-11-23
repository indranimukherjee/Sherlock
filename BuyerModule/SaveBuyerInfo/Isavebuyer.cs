using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerModule.SaveBuyerInfo
{
    interface Isavebuyer
    {
        int SaveBuyerDetails<T>(T buyer) where T : class;
        T SaveLeadDetails<T>(T lead) where T : class;
    }
}
