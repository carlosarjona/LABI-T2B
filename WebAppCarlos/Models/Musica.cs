using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppCarlos.Models
{
    public class Musica
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatorio")]
        [MaxLength(400,ErrorMessage = "Maximo 400 caracteres")]
        public string Titulo { get; set; }

        public Categoria Categoria { get; set; }

        public TipoMidia TipoMidea { get; set; }

        public DateTime DateTime { get; set; }
    }
}