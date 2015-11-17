using AutoMapper;
using DataAccessLayer.EF;
using DataCaptureModule.SaveLeads;
using DataCaptureModule.SpamFiltration;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using UtilityBusiness;

namespace DataCaptureModule.LeadScreening
{
    internal class LeadScreen : ILeadScreen
    {
        private readonly ISpamFilter _spamFilter;
        private readonly ISaveLead _saveLead;
        public LeadScreen()
        {
            _spamFilter = new SpamFilter();
            _saveLead = new SaveLead();
        }

        public int ScreenLead<T>(t_common_leads lead, Action<T> SendBackStatus)
        {


            lead.first_name = (string.IsNullOrEmpty(lead.first_name)) ? "" : Regex.Replace(lead.first_name, @"[^a-zA-Z]+", "");//remove special character and replace by space

            lead.last_name = (string.IsNullOrEmpty(lead.last_name)) ? "" : Regex.Replace(lead.last_name, @"[^a-zA-Z]+", "");

            lead.Home_Mobile_Phone1 = (string.IsNullOrEmpty(lead.Home_Mobile_Phone1)) ? "" : Regex.Replace(lead.Home_Mobile_Phone1, @"[^0-9]", "").Replace("+44", "0044");

            lead.Home_Mobile_Phone2 = (string.IsNullOrEmpty(lead.Home_Mobile_Phone2)) ? "" : Regex.Replace(lead.Home_Mobile_Phone2, @"[^0-9]", "").Replace("+44", "0044");

            lead.city = (string.IsNullOrEmpty(lead.city)) ? "" : Regex.Replace(lead.city, @"[^a-zA-Z-]+[^\s]+", "");

            lead.postcode = (string.IsNullOrEmpty(lead.postcode)) ? "" : Regex.Replace(lead.postcode, @"[^0-9a-zA-Z ]+", "");

            lead.address = (string.IsNullOrEmpty(lead.postcode)) ? "" : Regex.Replace(lead.address, @"[^0-9a-zA-Z-,' ]+", "");


            lead.email = (string.IsNullOrEmpty(lead.email)) ? "" : Regex.Replace(lead.email, @"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$", "");

            _saveLead.SaveLeadDetails<t_common_leads>(lead,1);

            t_common_leads_log commonLog = Mapper.Map<t_common_leads_log>(lead);
            commonLog.stage_id = (int)LeadStageEnum.Screened;
            commonLog.created_by = 2;
            commonLog.cretaed_on = DateTime.Now;

            _saveLead.SaveLeadDetails<t_common_leads_log>(commonLog);

            T leadStage = UtilityMethods.SetStages<T>(lead.lead_id, lead.source, GlobalConstants.Screened, GlobalConstants.NewStatus, lead.t_product_master.product_name);
            //M tk = (M)Convert.ChangeType(leadStage, typeof(M));

            SendBackStatus(leadStage);

            Thread.Sleep(GlobalConstants.SleepTime);

            int leadId = _spamFilter.FilterSpam(lead);

            return leadId;
        }
    }
}
