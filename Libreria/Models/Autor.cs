using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Autor
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("ISBN Autor")]
        [MinLength(1, ErrorMessage = "Error El ISBN del autor debe de ser mayor a 1 caractér")]
        public string Isbn { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Nombre Autor")]
        [MinLength(1, ErrorMessage= "Error El nombre del autor debe de ser mayor a 1 caractér")]
        public  string Name { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}