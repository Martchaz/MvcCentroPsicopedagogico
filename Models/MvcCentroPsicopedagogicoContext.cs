using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Models;
using MvcCentroPsicopedagogico.Models.ChatBot;
using MvcCentroPsicopedagogico.Models.Paciente;
using MvcCentroPsicopedagogico.Models.Usuarios;

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

        // <-- Agregá estos dos:
        public DbSet<ChatConversation> ChatConversations { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
