﻿namespace MvcCentroPsicopedagogico.Models.Paciente
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Otros campos según lo que necesites
    }
}
