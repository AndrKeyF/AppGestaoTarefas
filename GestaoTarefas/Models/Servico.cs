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


        [Required(ErrorMessage = "Introduza o nome")] 
        public string Nome { get; set; }
    }
}
