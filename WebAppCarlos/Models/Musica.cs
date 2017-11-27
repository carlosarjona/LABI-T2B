using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppCarlos.Models
{
    public class Musica
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public Categoria Categoria { get; set; }
        public TipoMidea TipoMidea { get; set; }
        public DateTime DateTime { get; set; }
    }
}