using DataCaptureModule.EntryPoint.CommonLead;
using DataCaptureModule.EntryPoint.Mortgage;
using System;
using UtilityBusiness;
using Microsoft.Practices.Unity;
using AutoMapper;
using DataAccessLayer.EF;

namespace DataCaptureModule.EntryPoint.Handler
{
    public class EntryHandler : IEntryHandler
    {
        private readonly CommonLeadEntry _leadEntry;

        public EntryHandler(string product)
        {
            if (product.Equals(GlobalConstants.Mortgage))
                _leadEntry = new MortgageLeadEntry();
            Mapper.CreateMap<t_mortgage_lead, t_mortgage_lead_log>();
            Mapper.CreateMap<t_common_leads, t_common_leads_log>();

            Mapper.CreateMap<AllFieldCapture, t_common_leads>();
            Mapper.CreateMap<AllFieldCapture, t_mortgage_lead>();
            //UnityConfig.RegisterComponents();
            //_leadEntry = UnityConfig.GetUnity().Resolve<CommonLeadEntry>(product);
        }

        public int CaptureLead<T>(AllFieldCapture lead, Action<T> SendBackStatus)
        {
            int leadId = 0;
            try
            {
                t_common_leads leadCommon = _leadEntry.CaptureLead<T, t_common_leads>(lead, SendBackStatus);
                leadId = leadCommon.lead_id;
            }
            catch (Exception ex)
            {
                UtilityMethods.SetStages<LeadStages>(0, "", "", ex.Message, lead.product_name);
            }
            return leadId;
        }
    }
}
