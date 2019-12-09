using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }

        [Required(ErrorMessage = "Insira o seu nome")]
        public string Nome  { get; set; }

        [Required(ErrorMessage = "Escolha a prioridade")]
        public Boolean Prioridade { get; set; }

        public DateTime Datain { get; set; }

        public DateTime Datafim { get; set; }



    }
}
