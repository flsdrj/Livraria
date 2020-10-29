using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }        
        public long Isbn { get; set; }
        public DateTime DataPublicacao { get; set; }
        public double Preco { get; set; }
        public string ImagemCapa { get; set; }
    }
}
