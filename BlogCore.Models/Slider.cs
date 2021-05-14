using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogCore.Models
{
    public class Slider
    {
        [Key]
        public int Id{ get; set; }

        [Required(ErrorMessage ="el nombre es obligatorio")]
        [Display(Name = "Nombre del Slider")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }


        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }



    }
}
