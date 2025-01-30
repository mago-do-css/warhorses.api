using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

public class Produto
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

public class ProdutoRepository
{
    private readonly FirebaseClient _firebaseClient;

    public ProdutoRepository(FirebaseClient firebaseClient)
    {
        _firebaseClient = firebaseClient;
    }

    public async Task<List<Produto>> GetAllProdutosAsync()
    {
        var produtos = await _firebaseClient
            .Child("produtos")
            .OnceAsync<Produto>();

        return produtos.Select(p => new Produto
        {
            Id = p.Key,
            Nome = p.Object.Nome,
            Preco = p.Object.Preco
        }).ToList();
    }

    public List<Produto> FiltrarProdutosPorPreco(List<Produto> produtos, decimal precoMinimo)
    {
        return produtos.Where(p => p.Preco >= precoMinimo).ToList();
    }
}
