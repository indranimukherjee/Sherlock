using AutoMapper;
using DataAccessLayer.EF;
using DataCaptureModule.AddFieldValue;
using DataCaptureModule.EntryPoint.CommonLead;
using DataCaptureModule.SaveLeads;
using System;
using UtilityBusiness;

namespace DataCaptureModule.EntryPoint.Mortgage
{
    internal class MortgageLeadEntry : CommonLeadEntry
    {
        private readonly ISaveLead _saveLead;
        private readonly IModifyValues _modifyValues;

        internal MortgageLeadEntry()
        {
            _saveLead = new SaveLead();
            _modifyValues = new MortgageModifyValues();
        }

        public override M CaptureLead<T, M>(AllFieldCapture lead, Action<T> SendBackStatus)
        {
            M leadCommon = base.CaptureLead<T, M>(lead, SendBackStatus);

            t_common_leads commonLead = (t_common_leads)Convert.ChangeType(leadCommon, typeof(t_common_leads));

            SaveMortgage<T>(lead, commonLead.lead_id, SendBackStatus);

            return leadCommon;

        }

        private void SaveMortgage<T>(AllFieldCapture lead, int leadId, Action<T> SendBackStatus)
        {
            t_mortgage_lead mortgage = Mapper.Map<t_mortgage_lead>(lead);
            mortgage.lead_id = leadId;
            mortgage.created_on = DateTime.Now;
            mortgage.created_by = 2;
            _saveLead.SaveLeadDetails<t_mortgage_lead>(mortgage);

            t_mortgage_lead_log mortgageLog = Mapper.Map<t_mortgage_lead_log>(mortgage);
            mortgageLog.created_on = DateTime.Now;
            mortgageLog.stage_id = (int)LeadStageEnum.Raw;

            _saveLead.SaveLeadDetails<t_mortgage_lead_log>(mortgageLog);

            _modifyValues.ModifyLeadValues(mortgage, SendBackStatus);
        }

    }
}
