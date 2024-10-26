using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TallerGestion.Hubs
{
    public class AtencionHub : Hub
    {
        public async Task NotificarNuevaAtencion(int oficinaId)
        {
            await Clients.All.SendAsync("NuevaAtencion", oficinaId);
        }

        public async Task NotificarAtencionActualizada(int oficinaId)
        {
            await Clients.All.SendAsync("AtencionActualizada", oficinaId);
        }
    }
}