using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Ex_3.Models
{
    public class Familia
    {
        [Key]
        public int Id_Familia { get; set; }
        [Required(ErrorMessage = "Campo Nome é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Apto é Obrigatório")]
        public int Apto { get; set; }



        [DisplayName("Nome do Condomínio")]
        public int Id_Condominio { get; set; }
        [DisplayName("Condomínio")]
        public Condominio condominio { get; set; }

        public ICollection<Morador> Moradors { get; set; }
    }
}
