using MvcCentroPsicopedagogico.Models;

namespace MvcCentroPsicopedagogico.Services
{
    public class AppointmentService : IAppointmentService
    {
        public Task<List<Turno>> GetAvailableAppointmentsAsync(UserContext userContext)
        {
            // Turnos simulados para mostrar en el chatbot
            var turnos = new List<Turno>
            {
                new Turno
                {
                    Id = 1,
                    NombrePaciente = "Disponible",
                    FechaHora = DateTime.Now.AddDays(1).AddHours(10),
                    Profesional = "Lic. Laura Gómez"
                },
                new Turno
                {
                    Id = 2,
                    NombrePaciente = "Disponible",
                    FechaHora = DateTime.Now.AddDays(2).AddHours(14),
                    Profesional = "Dr. Martín Pérez"
                }
            };

            return Task.FromResult(turnos);
        }
    }
}
