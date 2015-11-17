using DataAccessLayer.EF;
using DataAccessLayer.EF.Model.GenericRepository;

namespace DataCaptureModule.SaveLeads
{
    public class SaveLead : ISaveLead
    {
        public T SaveLeadDetails<T>(T lead, int save=0) where T : class
        {
            GenericRepository<T> gnr = new GenericRepository<T>(new SherlockdbEntities());
            if (save == 0)
                gnr.Insert(lead);
            else if (save == 1)
                gnr.Update(lead);

            return lead;
        }
    }
}
