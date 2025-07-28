using System.Text.Json;
using FlexPro.Client.Domain.Enums;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Response;

namespace FlexPro.Client.Infrastructure.Services;

public class ProdutoService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public ProdutoService(HttpClient http, JsonSerializerOptions options)
    {
        _http = http;
        _options = options;
    }

    public async Task<IEnumerable<ProdutoLojaResponse>> GetProdutoLoja()
    {
        var stream = await _http.GetStreamAsync("api/produto/produtoloja");
        return await JsonSerializer.DeserializeAsync<List<ProdutoLojaResponse>>(stream, _options) ?? new List<ProdutoLojaResponse>();; 
    }

    public async Task<IEnumerable<ProdutoLojaResponse>> GetProdutoLojaTeste()
    {
        var produtoLoja = new List<ProdutoLojaResponse>
        {
            new ProdutoLojaResponse
            {
                Id = 1,
                CodigoSistema = "21",
                Nome = "Neuter Super",
                Descricao = "Detergente neutro para uso geral",
                Cor = "#f1f2f4",
                Diluicao = "10% a 20%",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 1, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.FR, Tamanho = 5000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 1, Nome = "Cozinha" },
                    new Departamento { Id = 2, Nome = "Restaurantes" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 2,
                CodigoSistema = "22",
                Nome = "Power Desinfetante",
                Descricao = "Desinfetante concentrado para pisos",
                Cor = "#d1f2eb",
                Diluicao = "1% a 3%",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 2, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.GAL, Tamanho = 5000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 3, Nome = "Institucional" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 3,
                CodigoSistema = "23",
                Nome = "Cloro Ativo",
                Descricao = "Cloro para limpeza pesada e desinfecção",
                Cor = "#fef9e7",
                Diluicao = "5% a 10%",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 3, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.GAL, Tamanho = 5000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 4, Nome = "Lavanderias" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 4,
                CodigoSistema = "24",
                Nome = "Limpador Perfumado",
                Descricao = "Limpador com fragrância duradoura",
                Cor = "#fdebd0",
                Diluicao = "Pronto uso",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 4, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.FR, Tamanho = 2000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 3, Nome = "Institucional" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 5,
                CodigoSistema = "25",
                Nome = "Desengraxante Alcalino",
                Descricao = "Ideal para oficinas e áreas industriais",
                Cor = "#f6ddcc",
                Diluicao = "5% a 15%",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 5, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.GAL, Tamanho = 5000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 5, Nome = "Indústrias" },
                    new Departamento { Id = 6, Nome = "Automotivo" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 6,
                CodigoSistema = "26",
                Nome = "Sabonete Antisséptico",
                Descricao = "Sabonete líquido para higienização das mãos",
                Cor = "#f9ebea",
                Diluicao = "Pronto uso",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 6, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.FR, Tamanho = 1000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 3, Nome = "Institucional" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 7,
                CodigoSistema = "27",
                Nome = "Lava Louças Profissional",
                Descricao = "Detergente para máquina de lavar louças",
                Cor = "#eaf2f8",
                Diluicao = "Pronto uso",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 7, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.CX, Tamanho = 2000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 1, Nome = "Cozinha" }
                }
            },
            new ProdutoLojaResponse
            {
                Id = 8,
                CodigoSistema = "28",
                Nome = "Multiuso Citrus",
                Descricao = "Produto multiuso com aroma cítrico",
                Cor = "#fcf3cf",
                Diluicao = "5% a 10%",
                Embalagems = new List<Embalagem>
                {
                    new Embalagem { Id = 8, Quantidade = 1, TipoEmbalagem = TipoEmbalagem_e.FR, Tamanho = 1000 }
                },
                Departamentos = new List<Departamento>
                {
                    new Departamento { Id = 3, Nome = "Institucional" },
                    new Departamento { Id = 2, Nome = "Restaurantes" }
                }
            }
        };
        return produtoLoja;
    }

    public async Task<ProdutoLojaResponse> GetByIdAsync(int id)
    {
        var stream = await _http.GetStreamAsync($"api/produto/produtoloja/{id}");
        return await JsonSerializer.DeserializeAsync<ProdutoLojaResponse>(stream, _options) ?? new ProdutoLojaResponse();
    }
}