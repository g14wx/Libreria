using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Prestamo
    {
        public int ID { get; set; }
        [DisplayName("Fecha de retorno")]
        [Required(ErrorMessage = "Este campo es necesario")]
        public DateTime FechaRetorno { get; set; }
        [DisplayName("Fecha de prestamo (Hoy)")]
        [Required(ErrorMessage = "La fecha es necesaria")]
        public DateTime FechaDePrestamo { get; set; }
        [Required(AllowEmptyStrings = true)]
        public String Comentarios { get; set; } 
        `public int CopiaLibroID { get; set; }
        public virtual CopiaLIbro CopiaLIbro { get; set; }
        public int MiembroID { get; set; }
        public virtual Miembro Miembro { get; set; }
    }
}