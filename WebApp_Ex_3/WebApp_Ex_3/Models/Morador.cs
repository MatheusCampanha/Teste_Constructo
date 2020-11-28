using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Ex_3.Models
{
    public class Morador
    {
        [Key]
        public int Id_Morador { get; set; }
        [Required(ErrorMessage = "Campo Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo QtdBichos é Obrigatório")]
        [DisplayName("Quantidade Bichos")]
        public int QtdBichos { get; set; }

        [DisplayName("Nome da Família")]
        public int Id_Familia { get; set; }

        [DisplayName("Família")]
        public Familia familia { get; set; }
    }
}
