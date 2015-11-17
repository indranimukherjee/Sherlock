using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;

namespace BuyerModule.BuyerSettings.BuyerFace
{
    interface IBuyerFace
    {
        int GenerateBuyerFace<T>(T buyer) where T : class;

        //int GenerateBuyerFace(t_buyer_product_face buyer_face);

    }
}
