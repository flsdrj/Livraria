using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            //nome da tabela
            builder.ToTable("Livro");

            //chave primária
            builder.HasKey(c => c.IdLivro);

            //campos da tabela
            builder.Property(c => c.IdLivro)
                .HasColumnName("IdLivro");

            builder.Property(c => c.Isbn)
                .HasColumnName("Isbn")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Autor)
                .HasColumnName("Autor")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();   

            builder.Property(c => c.DataPublicacao)
                .HasColumnName("DataPublicacao")
                .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnName("Preco")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.ImagemCapa)
                .HasColumnName("ImagemCapa")
                .HasMaxLength(800)
                .IsRequired();
        }
    }
}
