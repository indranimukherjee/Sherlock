using System;

namespace UtilityBusiness
{
    public static class UtilityMethods
    {
        public static T SetStages<T>(int leadId, string source, string stage, string status, string product)
        {
            LeadStages leadStages = new LeadStages();
            leadStages.LeadId = leadId;
            leadStages.LeadSource = source;
            leadStages.LeadStage = stage;
            leadStages.LeadStatus = status;
            leadStages.ProductName = product;

            T leadStage = (T)Convert.ChangeType(leadStages, typeof(T));

            return leadStage;
        }
    }
}
