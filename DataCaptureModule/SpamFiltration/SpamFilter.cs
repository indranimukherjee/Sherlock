using DataAccessLayer.EF;
using DataAccessLayer.EF.Model.GenericRepository;
using DataCaptureModule.AddFieldValue;
using DataCaptureModule.SaveLeads;
using System.Collections.Generic;
using System.Linq;
using UtilityBusiness;

namespace DataCaptureModule.SpamFiltration
{
    internal class SpamFilter : ISpamFilter
    {
        private readonly IModifyValues _modifyValue;
        private readonly ISaveLead _saveLead;

        public SpamFilter()
        {
            _modifyValue = new CommonModifyValues();
            _saveLead = new SaveLead();
        }

        public int FilterSpam(t_common_leads lead)
        {
            List<t_common_leads> duplicates = IsDuplicateLead(lead.product_id, lead.ip_address, lead.email, lead.Home_Mobile_Phone1, lead.Home_Mobile_Phone2,lead.city,
                lead.postcode,lead.first_name,lead.last_name);
            if (duplicates.Count>0)
            {
                lead.status_id = (int)LeadStatusEnum.Duplicate;
                _saveLead.SaveLeadDetails<t_common_leads>(lead, 1);
            }

            //int leadId = _modifyValue.ModifyLeadValues(lead);

            return lead.lead_id;
        }

        public List<t_common_leads> IsDuplicateLead(int productId, string ip, string email, string homePhone, string workPhone, string city,string postcode, string firstname,string lastname)
        {
            List<t_common_leads> duplicates = null;
            using (var context = new SherlockdbEntities())
            {
                duplicates = (from item in context.t_common_leads
                             where item.product_id.Equals(productId)
                             && item.ip_address.Contains(ip)
                             || item.email.Equals(email)
                             || item.Home_Mobile_Phone1.Equals(homePhone)
                             || item.Home_Mobile_Phone2.Equals(workPhone)
                             || item.city.Equals(city) || item.postcode.Equals(postcode) 
                             || item.first_name.Equals(firstname) || item.last_name.Equals(lastname)
                              select item).ToList<t_common_leads>();
            }
            //gnr.
            return duplicates;
        }

        private bool SpamFlagCity(string city)
        {
            GenericRepository<t_hoax> gnr = new GenericRepository<t_hoax>(new SherlockdbEntities());
            t_hoax spamcity = gnr.GetFirst(x => x.Hoax_City == city);
            if (spamcity != null)
                return true;
            return false;
        }
        private bool SpamFlagPostCode(string postcode)
        {
            GenericRepository<t_hoax> gnr = new GenericRepository<t_hoax>(new SherlockdbEntities());
            t_hoax spampostcode = gnr.GetFirst(x => x.Hoax_Postcode == postcode);
            if (spampostcode != null)
                return true;

            return false;

        }

        private bool SpamFlagName(string firstname, string lastname)
        {
            GenericRepository<t_hoax> gnr = new GenericRepository<t_hoax>(new SherlockdbEntities());
            t_hoax spamfname = gnr.GetFirst(x => x.Hoax_fName == firstname);
            t_hoax spamlname = gnr.GetFirst(x => x.Hoax_lName == lastname);
            if (spamfname != null || spamlname != null)
                return true;

            return false;


        }
        private bool SpamFlagPhone(string Phone1, string phone2)
        {
            GenericRepository<t_hoax> gnr = new GenericRepository<t_hoax>(new SherlockdbEntities());
            t_hoax spamphone1 = gnr.GetFirst(x => x.hoax_Contactno1 == Phone1);
            t_hoax spamphone2 = gnr.GetFirst(x => x.hoax_Contactno2 == phone2);
            if (spamphone1 != null || spamphone2 != null)
                return true;
            return false;
        }


        private bool SpamFlagIp(string Ipaddress)
        {
            GenericRepository<t_hoax> gnr = new GenericRepository<t_hoax>(new SherlockdbEntities());

            t_hoax spamip = gnr.GetFirst(x => x.Hoax_ip == Ipaddress);
            if (spamip != null)
                return true;

            return false;

        }
        private bool SpamFlagEmail(string email)
        {
            //logic of spam check
            GenericRepository<t_hoax> gnr = new GenericRepository<t_hoax>(new SherlockdbEntities());

            t_hoax spamEmails = gnr.GetFirst(x => x.Hoax_Email == email);
            if (spamEmails != null)
                return true;

            return false;
        }

        private bool SpamCheck90Days(t_common_leads lead)
        {
            GenericRepository<t_common_leads> gnr = new GenericRepository<t_common_leads>(new SherlockdbEntities());

            List<t_common_leads> spamfields = (List<t_common_leads>)gnr.GetMany(x =>
           x.first_name.Equals(lead.first_name)
           && x.last_name.Equals(lead.last_name)
            && x.Home_Mobile_Phone1.Equals(lead.Home_Mobile_Phone1) && x.Home_Mobile_Phone2.Equals(lead.Home_Mobile_Phone2)
            && x.email.Equals(lead.email) && x.ip_address.Equals(lead.ip_address) && x.city.Equals(lead.city) &&
            x.postcode.Equals(lead.postcode));

            if (spamfields.Count > 0)
                return true;

            return false;
        }

    }
}
