using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModOrientacion.Models
{
    public class Adulto
    {
        [Key]
        public int IdAdulto {get; set;}
        public int ci {get; set;}
        public string? Nombres {get; set;}
        public string? ApellidoPaterno {get; set;}
        public string? ApellidoMaterno {get; set;}
        public int Edad {get; set;}
        public string? EstadoCivil {get; set;}
        public string? Domicilio {get; set;}
        public string? Trabaja {get; set;}
        public string? Discapacidad {get; set;}
        public int Telefono {get; set;}
    }
}