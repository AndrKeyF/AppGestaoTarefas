using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "Introduza o nome do departamento")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome inválido, tem de conter no mínimo 5 caracteres")]
        public string Nome { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}
