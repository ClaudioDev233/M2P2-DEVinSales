using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Api.Controllers;
using DevInSales.Api.Dtos;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Testes.DevInSales.Controllers
{
    public class ProductControllersTests
    {
        private readonly Mock<IProductService> _productService;
        private readonly ProductController _productController;

        public ProductControllersTests()
        {
            _productService = new Mock<IProductService>();
            _productController = new ProductController(_productService.Object);
        }

        [Fact]
        public void ObterProductPorId_PassandoUmIdValido_RetornaStatusCode200()
        {
            var produto = new Product("Teste", 10);
            _productService.Setup(mock => mock.ObterProductPorId(1)).Returns(produto);
            var actual = _productController.ObterProdutoPorId(1).Result;

            Assert.IsType<OkObjectResult>(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ObterProductPorId_PassandoUmIdInvalido_RetornaStatusCode404(int id)
        {
            _productService.Setup(mock => mock.ObterProductPorId(id)).Returns(value: null);
            var actual = _productController.ObterProdutoPorId(id).Result;
            Assert.IsType<NotFoundResult>(actual);
        }

        [Fact]
        public void Delete_PassandoUmIdValido_RetornaNoContent()
        {
            _productService.Setup(mock => mock.Delete(1));
            var actual = _productController.Delete(1);
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void Delete_PassandoUmIdInvalido_RetornaNotFound()
        {
            var exceptionMessage = "não existe";
            _productService.Setup(mock => mock.Delete(1)).Throws(new Exception(exceptionMessage));
            var actual = _productController.Delete(1);
            Assert.IsType<NotFoundResult>(actual);
        }

        [Fact]
        public void Delete_PassandoUmIdInvalido_RetornaBadRequest()
        {
            var exceptionMessage =
                "O produto especificado não pode ser excluido, porque já está atrelado a outra tabela!";
            _productService.Setup(mock => mock.Delete(1)).Throws(new Exception(exceptionMessage));
            var actual = _productController.Delete(1);
            Assert.IsType<BadRequestObjectResult>(actual);
        }

        [Fact]
        public void GetAll_PassandoParametrosValidos_RetornaStatusCode200()
        {
            var listaProdutos = new List<Product>() { new Product("Teste", 10), };
            _productService
                .Setup(mock => mock.ObterProdutos("Teste", 10, 20))
                .Returns(listaProdutos);
            var actual = _productController.GetAll("Teste", 10, 20).Result;
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetAll_PassandoParametrosValidos_RetornaStatusCode204()
        {
            var listaProdutos = new List<Product>();
            _productService
                .Setup(mock => mock.ObterProdutos("Teste", 10, 20))
                .Returns(listaProdutos);
            var actual = _productController.GetAll("Teste", 10, 20).Result;
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void GetAll_PrecoMaximoMenorQuePrecoMinimo_RetornaStatusCode400()
        {
            _productService.Setup(mock => mock.ObterProdutos("Teste", 30, 20));
            var actual = _productController.GetAll("Teste", 30, 20).Result;
            Assert.IsType<BadRequestObjectResult>(actual);
        }

        [Fact]
        public void PostProduct_PostaUmProdutoValido_Retorna201()
        {
            var product = new Product("Teste", 10);
            _productService.Setup(mock => mock.CreateNewProduct(product)).Returns(product.Id);
            var addProductModel = new AddProduct("Teste", 10);
            var actual = _productController.PostProduct(addProductModel);
            Assert.IsType<CreatedAtActionResult>(actual);
        }

        [Fact]
        public void PostProduct_InsereProdutoQueJaExiste_Retorna400()
        {
            var addProductModel = new AddProduct("Teste", 10);
            _productService.Setup(mock => mock.ProdutoExiste("Teste")).Returns(true);
            var actual = _productController.PostProduct(addProductModel);
            Assert.IsType<BadRequestObjectResult>(actual);
        }
    }
}
