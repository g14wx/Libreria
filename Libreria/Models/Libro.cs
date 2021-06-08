using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Libro
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Titulo del libro")]
        [MinLength(1, ErrorMessage = "Error El titulo del libro debe de ser mayor a 1 caractér")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Edición del libro")]
        [MinLength(1, ErrorMessage = "Error la Edición del libro debe de ser mayor a 1 caractér")]
        public string Edicion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Publicador del libro")]
        [MinLength(1, ErrorMessage = "Error el nombre del publicador del libro debe de ser mayor a 1 caractér")]
        public string Publicador { get; set; }

        public int AutorID { get; set; }
        public virtual Autor Autor { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<CopiaLIbro> CopiaLIbros { get; set; }
    }
}