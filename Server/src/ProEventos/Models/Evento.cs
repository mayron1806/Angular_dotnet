using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Models
{
    public class Evento
    {
        public int ID { get; set; }
        public string? Local { get; set; }
        public string? DataEvento { get; set; }
        public string? Tema { get; set; }
        public int QuantodadePessoas { get; set; }
        public string? Lote { get; set; }
        public string? ImagemURL { get; set; }
    }
}