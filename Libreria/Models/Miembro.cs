using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Miembro
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Error, por lo menos debe de tener un caractér")]
        [MinLength(1, ErrorMessage = "Error, por lo menos debe de tener un caractér")]
        [DisplayName("Nombre(s) del Miembro")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Error, por lo menos debe de tener un caractér")]
        [MinLength(1, ErrorMessage = "Error, por lo menos debe de tener un caractér")]
        [DisplayName("Apellido(s) del miembro")]
        public string Apellidos { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}