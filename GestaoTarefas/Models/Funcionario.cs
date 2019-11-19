using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Telemovel { get; set; }
        [Required]
        public string CC { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
