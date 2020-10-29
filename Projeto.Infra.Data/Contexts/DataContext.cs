using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        // Construtor para receber via injeção de depdencia         
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) //construtor da superclasse
        {

        }

        //Sobreescrita do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento
            modelBuilder.ApplyConfiguration(new LivroMapping());

        }

        //Declarar propriedade DbSet para cada entidade        
        public DbSet<Livro> Livro { get; set; }
    }
}
