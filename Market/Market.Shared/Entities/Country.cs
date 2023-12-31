﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display (Name = "Pais")]//Nombre proyectado
        [MaxLength (100,ErrorMessage = "El campo {0} puede tener maximo {1} " +
            "caracteres")]//longitud maxima del mensaje
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string? Name { get; set; }

        public ICollection<State> States { get; set; }//muchos states
    }
}
