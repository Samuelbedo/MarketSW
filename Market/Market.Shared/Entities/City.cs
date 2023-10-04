using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener maximo {1} " + "caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public State State { get; set; }//un solo estado
    }
}
