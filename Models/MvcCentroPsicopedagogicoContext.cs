using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Models.Paciente;
using MvcCentroPsicopedagogico.Models.Usuarios; // Asegúrate de tener el espacio de nombres correcto para tus modelos

namespace MvcCentroPsicopedagogico.Data
{
    public class MvcCentroPsicopedagogicoContext : DbContext
    {
        public MvcCentroPsicopedagogicoContext(DbContextOptions<MvcCentroPsicopedagogicoContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        // Aquí puedes agregar más DbSet para las entidades que necesites
    }
}
