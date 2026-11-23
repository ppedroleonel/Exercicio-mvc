using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio1.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 80 caracteres")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [MinLength(10, ErrorMessage = "Descrição deve ter no minimo 10 caracteres")]
        [Required(ErrorMessage = "A descrição é obrigatoria")]
        public string Descricao { get; set; } = string.Empty;
        
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local tem q ter entre 3 a 100 caracteres")]
        [Required(ErrorMessage = "Local é obrigatorio")]
        public string Local { get; set; } = string.Empty;
        
        public DateTime DataEvento {get;set;}

        [Range(1, 1000, ErrorMessage ="A quantidade de vagas é entre 1 a 1000")]
        public int QuantidadeVagas { get; set; }

        public decimal? ValorIngresso { get; set; }
    }
}