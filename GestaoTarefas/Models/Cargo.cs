using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Introduza o nome!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimo de letras 5 e máximo 50!!")]
        public string Nome { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } //tabela associado

}
}
