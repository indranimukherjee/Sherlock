using DataCaptureModule.SaveLeads;
using System;

namespace DataCaptureModule.AddFieldValue
{
    internal class CommonModifyValues : IModifyValues
    {
        private readonly ISaveLead _saveLead;
        public CommonModifyValues()
        {
            _saveLead = new SaveLead();
        }

        public int ModifyLeadValues<Y,M>(Y lead, Action<M> SendBackStatus)
        {
            //t_common_leads commonLead = (t_common_leads)Convert.ChangeType(lead, typeof(t_common_leads));

            //int leadId = _saveLead.SaveLeadDetails<t_common_leads>(commonLead,1).lead_id;

            //t_common_leads_log commonLog = Mapper.Map<t_common_leads_log>(commonLead);
            //commonLog.stage_id = (int)LeadStageEnum.ValueAdded;
            //_saveLead.SaveLeadDetails<t_common_leads_log>(commonLog);

            //Nothing to modify for common table data
            return 0;
        }
    }
}
