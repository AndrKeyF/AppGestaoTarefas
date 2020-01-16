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

        [Required(ErrorMessage = "Introduza o nome")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Nome inválido, tem de conter no mínimo 10 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza o Telemóvel")]
        [Phone(ErrorMessage = "Número Inválido")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Introduza o CC/BI")]
        [RegularExpression(@"\d{1,9}", ErrorMessage ="CC Inválido")]
        public string CC { get; set; }

        [Required(ErrorMessage = "Introduza o Email")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

    }
}
