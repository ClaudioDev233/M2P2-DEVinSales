using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Testes.DevInSales.Services
{
    public class ProductServiceTest
    {
        private DataContext _context;
        private ProductService _productService;
        public ProductServiceTest()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _productService = new ProductService(_context);
            Seed();
        }
        [Fact]
        public void ObterProductPorId_RetornaProduto()
        {
            var expected = _context.Products.FirstOrDefault(x => x.Id == 1);
            var actual = _productService.ObterProductPorId(1);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ProdutoExiste_RetornaTrue()
        {


            var actual = _productService.ProdutoExiste("Produto Teste");

            Assert.True(actual);
        }

        [Fact]
        public void ProdutoExiste_RetornaFalse()
        {
            var actual = _productService.ProdutoExiste("Produto Teste Não Existe");

            Assert.False(actual);
        }
   
        [Fact]
        public void ObterProdutos_RetornaListaSemParametros()
        {
            var expected = _context.Products.ToList();
            var actual = _productService.ObterProdutos(null, null, null);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ObterProdutos_RetornaListaPeloNomeDoProduto()
        {
            var name = "Produto Teste";
            var query = _context.Products.AsQueryable();
            var expected = query.Where(x => x.Name.ToUpper().Contains(name.ToUpper()));
            var actual = _productService.ObterProdutos("Produto Teste", null, null);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ObterProdutos_RetornaProdutosOndeOSuggestedPriceSejaMaiorOuIgualMeuPrecoMinimo()
        {
            var expected = _context.Products.Where(x => x.SuggestedPrice >= 10);
            var actual = _productService.ObterProdutos(null, 10, null);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ObterProdutos_RetornaProdutosOndeOSuggestedPriceSejaMenorOuIgualMeuPrecoMaximo()
        {
            var expected = _context.Products.Where(x => x.SuggestedPrice <= 20);
            var actual = _productService.ObterProdutos(null, null, 20);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateNewProduct_CriaUmNovoProdutoRetornaIdDoProdutoCriado()
        {
            var produto = new Product("Produto Criado", 2);
            // var produtoCriado = _context.Products.Add(produto);
            // _context.SaveChanges();
            var expected = _context.Products.Count() + 1;

            var actual = _productService.CreateNewProduct(produto);

            Assert.Equal(expected, actual);

        }
        public void Seed()
        {
            _context.Products.AddRange(new List<Product>(){
                new Product("Produto Teste", 10),
                new Product("Produto Teste2", 20),
                new Product("Produto Teste3", 15),
                new Product("Produto Teste4", 5),
                new Product("Produto Teste3", 14.99M),
        });
            _context.SaveChanges();
        }
    }
}