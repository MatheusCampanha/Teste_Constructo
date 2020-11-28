using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Ex_3.Models
{
    public class Condominio
    {
        [Key]
        public int Id_Condominio { get; set; }
        [Required(ErrorMessage ="Campo Nome é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Campo Bairro é Obrigatório")]
        public string Bairro { get; set; }

        public ICollection<Familia> Familias { get; set; }
    }
}
