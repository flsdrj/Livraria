using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Models
{
    public class LivroConsultaModel
    {
        
        public int IdLivro { get; set; }
        
        public long Isbn { get; set; }

        public string Autor { get; set; }
        
        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string ImagemCapa { get; set; }
    }
}
