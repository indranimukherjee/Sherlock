using DataAccessLayer.EF;
using System;

namespace DataCaptureModule.LeadScreening
{
    public interface ILeadScreen
    {
        int ScreenLead<T>(t_common_leads lead, Action<T> SendBackStatus);
    }
}
