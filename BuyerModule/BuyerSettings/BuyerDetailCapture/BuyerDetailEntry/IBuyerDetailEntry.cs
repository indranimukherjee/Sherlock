using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerModule.BuyerSettings.BuyerDetailCapture.BuyerDetailEntry
{
    interface IBuyerDetailEntry
    {
        T SaveBuyerDetails<T>(T lead) where T : class;
    }
}
