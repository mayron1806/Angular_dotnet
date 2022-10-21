using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class RedeSocial
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoID { get; set; }
        public Evento Evento { get; set; }
        public int? PalestrateID { get; set; }
        public Palestrante Palestrante { get; set; }

    }
}