using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;
using DataAccessLayer.EF.Model.GenericRepository;
using BuyerModule.BuyerSettings.BuyerFace;


namespace BuyerModule.BuyerSettings.productMapping
{
    class BuyerProductMapp : IBuyerMapp
    {
        private readonly IBuyerFace _buyerFace ;

        //public int BuyerProductMap<T>(T buyer) where T : class
        //{
        //    GenericRepository<T> gnr = new GenericRepository<T>(new sherlockEntities());
        //    gnr.Insert(buyer);

        //    return 0;


        public int BuyerProductMap(t_buyer_master buyer_info)
        {

            int leadId = _buyerFace.GenerateBuyerFace(buyer_info);

            return leadId;
        }

       
    }
    }
