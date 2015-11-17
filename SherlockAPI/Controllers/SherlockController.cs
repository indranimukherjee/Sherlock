using DataCaptureModule.EntryPoint.Handler;
using SignalRApp.SR;
using System;
using System.Web.Http;
using UtilityBusiness;

namespace SherlockAPI.Controllers
{
    public class SherlockController : ApiController
    {
        private IEntryHandler _entryHandler;

        [HttpPost]
        [ActionName("capturelead")]
        public IHttpActionResult CaptureLead(AllFieldCapture lead)
        {
            
            _entryHandler = new EntryHandler(lead.product_name);
            Action<LeadStages> ps = UpdateStatus;
            _entryHandler.CaptureLead<LeadStages>(lead, ps);
            return Ok();
        }        

        private void UpdateStatus(LeadStages status)
        {
            AutoUpdate.SendStatus(status);
        }
    }
    
}
