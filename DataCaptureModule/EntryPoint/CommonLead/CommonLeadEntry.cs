using AutoMapper;
using DataAccessLayer.EF;
using DataCaptureModule.LeadScreening;
using DataCaptureModule.SaveLeads;
using System;
using System.Threading;
using UtilityBusiness;

namespace DataCaptureModule.EntryPoint.CommonLead
{
    internal class CommonLeadEntry //: ILeadEntry
    {
        private readonly ILeadScreen _leadScreen;
        private readonly ISaveLead _saveLead;
        public CommonLeadEntry()
        {
            _leadScreen = new LeadScreen();
            _saveLead = new SaveLead();
        }

        public virtual Y CaptureLead<T, Y>(AllFieldCapture lead, Action<T> SendBackStatus)
        {
            t_common_leads commonLead = Mapper.Map<t_common_leads>(lead);

            commonLead.status_id = (int)LeadStatusEnum.New;
            commonLead.created_by = 2;
            commonLead.created_on = DateTime.Now;

            int leadId = _saveLead.SaveLeadDetails<t_common_leads>(commonLead).lead_id;

            t_common_leads_log commonLog = Mapper.Map<t_common_leads_log>(commonLead);
            commonLog.lead_id = leadId;
            commonLog.stage_id = (int)LeadStageEnum.Raw;
            commonLog.created_by = 2;
            commonLog.cretaed_on = DateTime.Now;

            _saveLead.SaveLeadDetails<t_common_leads_log>(commonLog);

            T leadStage = UtilityMethods.SetStages<T>(leadId, lead.source, GlobalConstants.RawSaved, GlobalConstants.NewStatus, lead.product_name);
            //M tk = (M)Convert.ChangeType(leadStage, typeof(M));

            SendBackStatus(leadStage);

            Thread.Sleep(GlobalConstants.SleepTime);

            Y leadCommon = (Y)Convert.ChangeType(commonLead, typeof(Y));

            _leadScreen.ScreenLead(commonLead, SendBackStatus);
            return leadCommon;
        }

    }
}
