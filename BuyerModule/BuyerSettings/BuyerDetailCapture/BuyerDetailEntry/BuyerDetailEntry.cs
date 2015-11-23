using BuyerModule.BuyerSettings.productMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;
using BuyerModule.SaveBuyerInfo;

namespace BuyerModule.BuyerSettings.BuyerDetailCapture.BuyerDetailEntry
{
    public class BuyerDetailEntry : IBuyerDetailEntry
    {
        private readonly Isavebuyer _savebuyer;
        private readonly IBuyerMapp _buyermapp;
        public BuyerDetailEntry()
        {
            _savebuyer = new Savebuyer();
        }
        public T SaveBuyerDetails<T>(T lead) where T : class
        {
            return _savebuyer.SaveLeadDetails<T>(lead);
        }


        //public virtual int CaptureBuyerInfo(BuyerInfoCapture Buyer)
        //{

        //    t_buyer_master buyerinfo = new t_buyer_master()
        //    {
        //        buyer_name = Buyer.buyer_name,
        //        buyer_address = Buyer.buyer_address,
        //        buyer_pincode = Buyer.buyer_pincode,
        //        buyer_poc_name = Buyer.buyer_poc_name,
        //        buyer_contact_number = Buyer.buyer_contact_number,
        //        buyer_poc_contact_number = Buyer.buyer_poc_contact_number,
        //        buyer_type =Buyer.buyer_type
        //    };

        //    int buyer_id = _savebuyer.SaveBuyerDetails<t_buyer_master>(buyerinfo);
        //    buyerinfo.buyer_id = buyer_id;
        //    _buyermapp.BuyerProductMap(buyerinfo);
        //    return buyer_id;
        //}

        
    }
}
