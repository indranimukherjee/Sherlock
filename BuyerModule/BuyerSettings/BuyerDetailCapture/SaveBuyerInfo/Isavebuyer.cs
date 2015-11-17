using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerModule.BuyerSettings.BuyerDetailCapture.SaveBuyerInfo
{
    interface Isavebuyer
    {
        int SaveBuyerDetails<T>(T buyer) where T : class;

    }
}
