using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class LivroEdicaoModel
    {
        [Required(ErrorMessage = "Informe o id do Livro.")]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "Informe o ISBN do Livro.")]
        public long Isbn { get; set; }

        [Required(ErrorMessage = "Informe o Autor do Livro.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Informe o nome do Livro.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o valor do Livro.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Informe o data de Publicação do Livro.")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "Informe a imagem do Livro.")]
        public string ImagemCapa { get; set; }

    }
}
