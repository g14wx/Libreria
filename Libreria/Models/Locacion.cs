using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Locacion
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Error, la copia del libro debe de colocarse en una sección")]
        [DisplayName("Numero de Sección")]
        [Range(0,int.MaxValue,ErrorMessage = "Error, minimo aceptado 0")]
        public int Nseccion { get;set; }
        [Required(ErrorMessage = "Error, la copia del libro debe de colocarse en un armario")]
        [DisplayName("Numero de Armario")]
        [Range(0, int.MaxValue, ErrorMessage = "Error, minimo aceptado 0")]
        public int Narmario { get; set; }
        [Required(ErrorMessage = "Error, la copia del libro debe de colocarse en una fila")]
        [DisplayName("Numero de Fila")]
        [Range(0, int.MaxValue, ErrorMessage = "Error, minimo aceptado 0")]
        public int NFila { get; set; }
        public virtual ICollection<CopiaLIbro> CopiaLIbros { get; set; }
    }
}