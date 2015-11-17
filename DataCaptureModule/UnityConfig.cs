using AutoMapper;
using DataAccessLayer.EF;
using DataCaptureModule.AddFieldValue;
using DataCaptureModule.EntryPoint.CommonLead;
using DataCaptureModule.EntryPoint.Handler;
using DataCaptureModule.EntryPoint.Mortgage;
using DataCaptureModule.LeadScreening;
using DataCaptureModule.SaveLeads;
using DataCaptureModule.SpamFiltration;
using Microsoft.Practices.Unity;
using UtilityBusiness;

namespace DataCaptureModule
{
    public static class UnityConfig
    {
        private static readonly IUnityContainer container;

        static UnityConfig()
        {
            container = new UnityContainer();
        }

        public static object GlobalConfiguration { get; private set; }

        public static IUnityContainer GetUnity()
        {
            return container;
        }

        public static void RegisterComponents()
        {
            //container.RegisterType<ILeadEntry, CommonLeadEntry>("common");
            container.RegisterType<CommonLeadEntry, MortgageLeadEntry>(GlobalConstants.Mortgage);
            //put other products like lifeinsurance etc..

            container.RegisterType<IEntryHandler, EntryHandler>();

            container.RegisterType<IModifyValues, CommonModifyValues>();
            container.RegisterType<IModifyValues, MortgageModifyValues>();
            container.RegisterType<ILeadScreen, LeadScreen>();
            container.RegisterType<ISpamFilter, SpamFilter>();
            container.RegisterType<ISaveLead, SaveLead>();
            container.RegisterType<IModifyValues, MortgageModifyValues>();

            //automapper
            Mapper.CreateMap<t_mortgage_lead, t_mortgage_lead_log>();
            Mapper.CreateMap<t_common_leads, t_common_leads_log>();

        }
    }
}
