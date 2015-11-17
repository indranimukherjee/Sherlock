using Microsoft.AspNet.SignalR;
using UtilityBusiness;

namespace SignalRApp.SR
{
    public class AutoUpdate : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public static void SendStatus<T>(T status)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<AutoUpdate>();
            context.Clients.All.broadcastMessage(status);
        }
    }
}