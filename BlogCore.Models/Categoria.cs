﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCore.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Inressa un nombre para la categoria")]
        [Display(Name ="Nombre categoria")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Orden de visualizacion ")]
        public int Orden { get; set; }







    }
}
