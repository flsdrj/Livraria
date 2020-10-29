using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository livroRepository;

        //injeção de dependencia
        public LivroController(ILivroRepository livroRepository)
        {
            this.livroRepository = livroRepository;

        }

        [HttpPost]
        public IActionResult Post(LivroCadastroModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var livro = new Livro();

                livro.Nome = model.Nome;
                livro.Isbn = model.Isbn;
                livro.Autor = model.Autor;
                livro.DataPublicacao = model.DataPublicacao;
                livro.Preco = model.Preco;
                livro.ImagemCapa = model.ImagemCapa;

                var consulta = livroRepository.Consultar();
                var isbnjacadastrado = false;

                foreach (var item in consulta)
                {
                    if (item.Isbn == model.Isbn)
                        isbnjacadastrado = true;

                }

                if (isbnjacadastrado)
                {
                    return BadRequest("Livro não cadastrado, Isbn já existente.");
                }
                else
                {
                    livroRepository.Inserir(livro);

                    var result = new
                    {
                        mensagem = "Livro cadastrado com sucesso.",
                        livro
                    };

                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(LivroEdicaoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                var livro = livroRepository.ObterPorId(model.IdLivro);

                if (livro == null)
                    return BadRequest("Livro não encontrado");

                livro.Nome = model.Nome;
                livro.Autor = model.Autor;
                livro.Isbn = model.Isbn;
                livro.DataPublicacao = model.DataPublicacao;
                livro.Preco = model.Preco;
                livro.ImagemCapa = model.ImagemCapa;


                livroRepository.Alterar(livro);

                var result = new
                {
                    mensagem = "Livro atualizado com sucesso!",
                    livro
                };               

                return Ok(result);

            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro" + e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var livro = livroRepository.ObterPorId(id);

                if (livro == null)
                    return BadRequest("Livro não encontrado.");

                livroRepository.Excluir(livro);

                var result = new
                {
                    mensagem = "Livro excluido com sucesso!",
                    livro
                };

                return Ok(result);


            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro" + e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //executando a consulta de livros
                var consulta = livroRepository.Consultar();
                var result = new List<LivroConsultaModel>();

                foreach (var item in consulta)
                {
                    var model = new LivroConsultaModel()
                    {
                        IdLivro = item.IdLivro,
                        Nome = item.Nome,
                        Autor = item.Autor,
                        Isbn = item.Isbn,
                        DataPublicacao = item.DataPublicacao,
                        Preco = item.Preco,
                        ImagemCapa = item.ImagemCapa
                    };

                    result.Add(model); //adicionando na lista

                }
                return Ok(result);

            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro " + e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(LivroConsultaModel))]
        public IActionResult GetById(int id)
        {
            try
            {
                //executando a consulta de livros
                var consulta = livroRepository.ObterPorId(id);

                if (consulta == null)
                    return NoContent(); //vazio..

                var result = new LivroConsultaModel()
                {
                    IdLivro = consulta.IdLivro,
                    Nome = consulta.Nome,
                    Autor = consulta.Autor,
                    Isbn = consulta.Isbn,
                    DataPublicacao = consulta.DataPublicacao,
                    Preco = consulta.Preco,
                    ImagemCapa = consulta.ImagemCapa
                };

                return Ok(result);

            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro " + e.Message);
            }
        }

        [HttpGet("{isbn:long}")]
        public IActionResult GetByIsbn(long isbn)
        {
            try
            {
                //executando a consulta de livros
                var consulta = livroRepository.Consultar();
                var result = new List<LivroConsultaModel>();

                foreach (var item in consulta)
                {

                    var model = new LivroConsultaModel()
                    {
                        IdLivro = item.IdLivro,
                        Nome = item.Nome,
                        Autor = item.Autor,
                        Isbn = item.Isbn,
                        DataPublicacao = item.DataPublicacao,
                        Preco = item.Preco,
                        ImagemCapa = item.ImagemCapa
                    };

                    if (item.Isbn == isbn)
                    {
                        result.Add(model);
                    }

                }
                return Ok(result);

            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro " + e.Message);
            }
        }

    }
}