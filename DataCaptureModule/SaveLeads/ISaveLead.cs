namespace DataCaptureModule.SaveLeads
{
    interface ISaveLead
    {
        T SaveLeadDetails<T>(T lead, int save = 0) where T : class;
    }
}
