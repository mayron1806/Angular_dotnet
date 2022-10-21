using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        public int EventoID { get; set; }
        public Evento Evento { get; set; }
        public int PalestranteID { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}