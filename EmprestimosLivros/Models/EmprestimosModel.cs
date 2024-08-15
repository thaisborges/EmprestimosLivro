﻿using System.ComponentModel.DataAnnotations;

namespace EmprestimosLivros.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Recebedor!")]
        public string Recebedor  { get; set; }
        
        [Required(ErrorMessage = "Digite o nome do Fornecedor!")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "Digite o nome do LivroEmprestado!")]
        public string LivroEmprestado { get; set; }

        [Required(ErrorMessage = "Digite o nome do Recebedor!")]
        public DateTime dataUltimaAtualizacao { get; set; } = DateTime.Now;

    }
}
