using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener maximo {1} " + "caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; }

        public Country Country { get; set; }//un solo pais

        public ICollection<City> Cities { get; set;}//muchas ciudades
    }
}
