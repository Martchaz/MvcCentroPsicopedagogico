using MvcCentroPsicopedagogico.Models;


namespace MvcCentroPsicopedagogico.Services
{
    public interface IAppointmentService
    {
        Task<List<Turno>> GetAvailableAppointmentsAsync(UserContext userContext);
    }
}
