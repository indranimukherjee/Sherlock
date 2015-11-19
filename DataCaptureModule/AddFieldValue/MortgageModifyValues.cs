using AutoMapper;
using DataAccessLayer.EF;
using DataCaptureModule.SaveLeads;
using System;
using UtilityBusiness;

namespace DataCaptureModule.AddFieldValue
{
    internal class MortgageModifyValues : IModifyValues
    {
        private readonly ISaveLead _saveLead;

        public MortgageModifyValues()
        {
            _saveLead = new SaveLead();
        }

        public int ModifyLeadValues<Y, M>(Y lead, Action<M> SendBackStatus)
        {
            t_mortgage_lead mortgage = (t_mortgage_lead)Convert.ChangeType(lead, typeof(t_mortgage_lead));

            int age = DateTime.Now.Year - mortgage.date_of_birth.Year;
            mortgage.age = age;


            int leadId = _saveLead.SaveLeadDetails<t_mortgage_lead>(mortgage, 1).lead_id;

            t_mortgage_lead_log mortgageLog = Mapper.Map<t_mortgage_lead_log>(mortgage);
            mortgageLog.ltv = GetFormattedScore(GetPercentageRounded(mortgageLog.loan_value, mortgageLog.property_value));

            mortgageLog.stage_id = (int)LeadStageEnum.ValueAdded;
            mortgageLog.created_on = DateTime.Now;
            _saveLead.SaveLeadDetails<t_mortgage_lead_log>(mortgageLog);

            M leadStage = UtilityMethods.SetStages<M>(mortgage.lead_id, "", GlobalConstants.Modified, GlobalConstants.NewStatus, GlobalConstants.Mortgage);
            //M tk = (M)Convert.ChangeType(leadStage, typeof(M));

            SendBackStatus(leadStage);

            return leadId;
        }

        private string GetFormattedScore(decimal? score, bool hidePercentSymbol = false)
        {
            if (score != null)
            {
                score = Math.Round(score ?? 0, 2, MidpointRounding.AwayFromZero);
                string result = ((decimal)score).ToString("p0").Replace(" ", "");
                if (hidePercentSymbol) result = result.Replace("%", "");
                return result;
            }
            return "n/a";
        }

        private decimal? GetPercentageRounded(int d1, int d2)
        {
            if (d2 != 0)
                return ((decimal)d1 / d2);

            return null;
        }









    }
}
