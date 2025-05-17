namespace MvcCentroPsicopedagogico.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string NombrePaciente { get; set; }
        public DateTime FechaHora { get; set; }
        public string Profesional { get; set; }
        public override string ToString()
        {
            return $"{FechaHora:dd/MM/yyyy HH:mm} con {Profesional}";
        }

    }

}
