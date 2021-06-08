using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Titulo de la Categoria")]
        [MinLength(1, ErrorMessage = "Error El titulo de la categoria debe de ser mayor a 1 caractér")]
        public string Cat { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}