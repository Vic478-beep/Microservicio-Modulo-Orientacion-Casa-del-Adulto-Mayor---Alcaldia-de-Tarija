using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModOrientacion.Models
{
    public class FichaOri
    {
        [Key]
        public int CodFicha {get; set;}
        public string? FechaIngreso {get; set;}
        public string? TipoOrientacion {get; set;}
        public string? Motivo {get; set;}
        public string? ResultadoObtenido {get; set;}
        public int IdAdulto {get; set;}
        [ForeignKey(nameof(IdAdulto))]
        public Adulto? adulto {get; set;}
    }
}