using Microsoft.AspNetCore.SignalR;

namespace SignalRApp01.Hubs
{
    public class TimeHub : Hub
    {
        public async Task SendTimeToClients()
        {
            while (true)
            {
                await Clients.All.SendAsync("ReceiveTime", DateTime.Now.ToString("HH:mm:ss"));
                await Task.Delay(1000); // 1초마다 업데이트
            }
        }
    }
}
