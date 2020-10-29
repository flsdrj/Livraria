using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        //atributo
        private readonly DataContext dataContext;

        //Construtor para injeção de dependencia
        public LivroRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }
               
    }
}
