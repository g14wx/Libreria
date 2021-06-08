using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public enum Estado
    {
        Excelente, Bueno, Regular, Deteriorado, Malo
    }
    public class CopiaLIbro
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Identificador de la copia de este libro")]
        [MinLength(1, ErrorMessage = "Error El Identificador de la copia del libro debe de ser mayor a 1 caractér")]
        public string Identificador { get; set; }
        [DefaultValue(true)]
        [DisplayName("Estado de disponibilidad del libro")]
        public bool Estado { get; set; }

        [DisplayName("Estado Fisico del Libro")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public Estado EstadoGeneral { get; set; }
        public int LibroID { get; set; }
        public virtual Libro Libro { get; set; }
        public int LocacionID { get; set; }
        public virtual Locacion Locacion { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}