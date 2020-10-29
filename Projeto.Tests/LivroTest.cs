using FluentAssertions;
using Newtonsoft.Json;
using Projeto.Infra.Data.Entities;
using Projeto.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Tests
{
    public class LivroTest
    {
        //attributos
        private readonly AppContext appContext;
        private readonly string endpoint;


        public LivroTest()
        {
            appContext = new AppContext();
            endpoint = "/api/Livro";
        }

        [Fact] //método para execução de teste do XUnit
               //async -> método executado como uma Thread (assincrono)
        public async Task Livro_Post_ReturnsOk()
        {
            //preencher os campos da model
            var modelCadastro = new LivroCadastroModel()
            {
                Nome = "Biografia de Francisco",
                Isbn = 12345678,
                Autor = "Francisco Luiz",
                Preco = 120.00,
                DataPublicacao = new DateTime(1979, 04, 27),
                ImagemCapa = "https://www.infoescola.com/wp-content/uploads/2017/04/cegonha-0470854409.jpg"
            };

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                             Encoding.UTF8, "application/json");
            var responseCadastro = await appContext.Client.PostAsync(endpoint, requestCadastro);

            var resultCadastro = string.Empty;
            using (HttpContent content = responseCadastro.Content)
            {
                Task<string> r = content.ReadAsStringAsync();
                resultCadastro += r.Result;
            }

            var resposta = JsonConvert.DeserializeObject<ResultModel>(resultCadastro);

            //verificação de teste
            responseCadastro.StatusCode.Should().Be(HttpStatusCode.OK);
            resposta.Mensagem.Should().Be("Livro cadastrado com sucesso.");
        }

        [Fact]
        public async Task Livro_Post_ReturnsBadRequest()
        {

            var model = new LivroCadastroModel()
            {
                Nome = string.Empty,
                Isbn = 0,
                Autor = string.Empty,
                Preco = 0,
                DataPublicacao = new DateTime(0001, 01, 01),
                ImagemCapa = string.Empty
            };


            var request = new StringContent(JsonConvert.SerializeObject(model),
            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            //critério de teste (Serviço da API retornar HTTP BADREQUEST (400))
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Livro_Put_ReturnsOk()
        {

            var modelCadastro = new LivroEdicaoModel()
            {
                Nome = "A vida de Francisco",
                Isbn = 9780980200447,
                Autor = "Francisco Luiz",
                Preco = 120.00,
                DataPublicacao = new DateTime(1979, 01, 01),
                ImagemCapa = "https://images-na.ssl-images-amazon.com/images/I/41UdKOYfPJL._SR600,315_SCLZZZZZZZ_.jpg"
            };

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                            Encoding.UTF8, "application/json");

            var responseCadastro = await appContext.Client.PostAsync(endpoint, requestCadastro);

            var resultCadastro = string.Empty;
            using (HttpContent content = responseCadastro.Content)
            {
                Task<string> r = content.ReadAsStringAsync();
                resultCadastro += r.Result;
            }

            var respostaCadastro = JsonConvert.DeserializeObject<ResultModel>(resultCadastro);

            //verificação de teste
            responseCadastro.StatusCode.Should().Be(HttpStatusCode.OK);
            respostaCadastro.Mensagem.Should().Be("Livro cadastrado com sucesso.");


            //--------------atualizando o livro cadastrado na API
            var modelEdicao = new LivroEdicaoModel()
            {
                IdLivro = respostaCadastro.Livro.IdLivro,
                Nome = "A vida de Francisco Luiz",
                Isbn = 9780980543447,
                Autor = "Francisco Luiz Bezerra",
                Preco = 160.00,
                DataPublicacao = new DateTime(1990, 05, 10),
                ImagemCapa = "https://images-submarino.b2w.io/produtos/imagens/122758274/122758282_1GG.jpg"
            };

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                            Encoding.UTF8, "application/json");
            var responseEdicao = await appContext.Client.PutAsync(endpoint, requestEdicao);

            var resultEdicao = string.Empty;
            using (HttpContent content = responseEdicao.Content)
            {
                Task<string> r = content.ReadAsStringAsync();
                resultEdicao += r.Result;
            }

            var respostaEdicao = JsonConvert.DeserializeObject<ResultModel>(resultEdicao);

            //verificação de teste
            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);
            respostaEdicao.Mensagem.Should().Be("Livro atualizado com sucesso!");
        }


        [Fact]
        public async Task Livro_Put_ReturnsBadRequest()
        {

            var model = new LivroEdicaoModel()
            {
                Nome = string.Empty,
                Isbn = 0,
                Autor = string.Empty,
                Preco = 0,
                DataPublicacao = new DateTime(0001, 01, 01),
                ImagemCapa = string.Empty
            };

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "applicataion/json");

            var response = await appContext.Client.PutAsync(endpoint, request);

            //criterio de teste (Serviço da API retornar HTTP BADREQUEST (400))
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Livro_Delete_ReturnsOk()
        {
            var modelCadastro = new LivroEdicaoModel()
            {
                Nome = "A vida de Francisco",
                Isbn = 9780980444447,
                Autor = "Francisco Luiz",
                Preco = 120.00,
                DataPublicacao = new DateTime(1979, 01, 01),
                ImagemCapa = "https://images-na.ssl-images-amazon.com/images/I/41UdKOYfPJL._SR600,315_SCLZZZZZZZ_.jpg"
            };

            var requestCadastro = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                            Encoding.UTF8, "application/json");
            var responseCadastro = await appContext.Client.PostAsync(endpoint, requestCadastro);

            var resultCadastro = string.Empty;
            using (HttpContent content = responseCadastro.Content)
            {
                Task<string> r = content.ReadAsStringAsync();
                resultCadastro += r.Result;
            }

            var respostaCadastro = JsonConvert.DeserializeObject<ResultModel>(resultCadastro);

            //verificação de teste
            responseCadastro.StatusCode.Should().Be(HttpStatusCode.OK);
            respostaCadastro.Mensagem.Should().Be("Livro cadastrado com sucesso.");


            //--------------excluindo o cliente cadastrado na API  
            var responseExclusao = await appContext.Client.DeleteAsync
                (endpoint + "/" + respostaCadastro.Livro.IdLivro);

            var resultExclusao = string.Empty;
            using (HttpContent content = responseExclusao.Content)
            {
                Task<string> r = content.ReadAsStringAsync();
                resultExclusao += r.Result;
            }

            var respostaExclusao = JsonConvert.DeserializeObject<ResultModel>(resultExclusao);

            //verificação de teste
            responseExclusao.StatusCode.Should().Be(HttpStatusCode.OK);
            respostaExclusao.Mensagem.Should().Be("Livro excluido com sucesso!");
        }

        [Fact]
        public async Task Livro_GetAll_ReturnsOk()
        {
            var response = await appContext.Client.GetAsync(endpoint);

            //criterio de teste (Serviço da API retornar HTTP OK (200))
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Livro_GetById_ReturnsOk()
        {           

            var response = await appContext.Client.GetAsync(endpoint + "/" + 1);

            //criterio de teste (Serviço da API retornar HTTP OK (200))
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        public class ResultModel
        {
            public string Mensagem { get; set; }
            public Livro Livro { get; set; }
        }
        
    }
}
