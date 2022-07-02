using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Api.Controllers;
using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Testes.DevInSales.Controllers
{
    public class SaleControllerTests
    {
        private readonly SalesController _salesController;
        private readonly Mock<ISaleService> _saleService;

        public SaleControllerTests()
        {
            _saleService = new Mock<ISaleService>();
            _salesController = new SalesController(_saleService.Object);
        }

        [Fact]
        public void GetSaleById_PassandoUmIdValido_RetornaStatusCode200()
        {
            //procuro a sale por id
            //retorno um 200
            var sale = new SaleResponse(
                1,
                "teste",
                "teste2",
                new DateTime(),
                new List<SaleProductResponse>()
            );

            _saleService.Setup(mock => mock.GetSaleById(1)).Returns(sale);

            var actual = _salesController.GetSaleById(1).Result as OkObjectResult;

            // Assert.IsAssignableFrom<OkObjectResult>(actual);
            Assert.Equal(200, actual.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetSaleById_PassandoIdInvalido_RetornaNotFound(int id)
        {
            _saleService.Setup(mock => mock.GetSaleById(id)).Returns(value: null);

            var actual = _salesController.GetSaleById(id).Result as NotFoundResult;

            Assert.IsType<NotFoundResult>(actual);
            Assert.Equal(404, actual.StatusCode);
        }

        [Fact]
        public void GetSalesBySellerId_PassandoSellerIdValido_RetornaStatusCode200()
        {
            var sales = new List<Sale> { new Sale(1, 2, DateTime.Now) };

            _saleService.Setup(mock => mock.GetSaleBySellerId(1)).Returns(sales);

            var actual = _salesController.GetSalesBySellerId(1).Result as OkObjectResult;
            Assert.IsAssignableFrom<OkObjectResult>(actual);
            Assert.Equal(200, actual.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetSalesBySellerId_PassandoSellerIdInvalido_RetornaContent(int id)
        {
            var sales = new List<Sale>();
            _saleService.Setup(mock => mock.GetSaleBySellerId(id)).Returns(sales);
            var actual = _salesController.GetSalesBySellerId(id).Result;
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void GetSalesByBuyerId_PassandoBuyerIdValido_RetonaStatusCode200()
        {
            var sales = new List<Sale> { new Sale(1, 2, DateTime.Now) };
            _saleService.Setup(mock => mock.GetSaleByBuyerId(1)).Returns(sales);
            var actual = _salesController.GetSalesByBuyerId(1).Result as OkObjectResult;
            Assert.Equal(200, actual.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetSalesByBuyerId_PassandoBuyerIdInvalido_RetornaNoContent(int id)
        {
            var sales = new List<Sale>();
            _saleService.Setup(mock => mock.GetSaleByBuyerId(id)).Returns(sales);
            var actual = _salesController.GetSalesByBuyerId(id).Result;
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void CreateSaleBySellerId_CriaUmUsuario_RetornaCreated201()
        {
            var sale = new Sale(1, 2, DateTime.Now);
            _saleService.Setup(mock => mock.CreateSaleByUserId(sale)).Returns(sale.Id);
            var saleRequest = new SaleBySellerRequest(1, DateTime.Now);
            var actual =
                _salesController.CreateSaleBySellerId(1, saleRequest).Result
                as CreatedAtActionResult;
            Assert.Equal(201, actual.StatusCode);
        }

        [Fact]
        public void UpdateUnitPrice_PassandoTodosParametrosValidos_AlteraPrecoRetornaNoContent()
        {
            _saleService.Setup(mock => mock.UpdateUnitPrice(1, 1, 10));

            var actual = _salesController.UpdateUnitPrice(1, 1, 10);
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void UpdateUnitPrice_PassandoTodosParametrosInvalidos_RetornaBadRequest()
        {
            _saleService
                .Setup(mock => mock.UpdateUnitPrice(1, 1, -1))
                .Throws(new ArgumentException());
            var actual = _salesController.UpdateUnitPrice(1, 1, -1);

            Assert.IsType<BadRequestResult>(actual);
        }

        [Fact]
        public void UpdateUnitPrice_PassandoParametrosInvalidos_RetornaNotFound()
        {
            _saleService.Setup(mock => mock.UpdateUnitPrice(1, 1, 10)).Throws(new Exception());
            var actual = _salesController.UpdateUnitPrice(1, 1, 10);

            Assert.IsType<NotFoundResult>(actual);
        }

        [Fact]
        public void UpdateAmount_PassandoTodosParametrosValidos_AlteraPrecoRetornaNoContent()
        {
            _saleService.Setup(mock => mock.UpdateAmount(1, 1, 5));

            var actual = _salesController.UpdateAmount(1, 1, 5);
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void CreateSaleByBuyerId_CriaUmSale_RetornaCreated201()
        {
            var sale = new Sale(1, 2, DateTime.Now);
            _saleService.Setup(mock => mock.CreateSaleByUserId(sale)).Returns(sale.Id);
            var saleRequest = new SaleByBuyerRequest(1, DateTime.Now);
            var actual =
                _salesController.CreateSaleByBuyerId(1, saleRequest).Result
                as CreatedAtActionResult;
            Assert.Equal(201, actual.StatusCode);
        }

        [Fact]
        public void GetDeliveryById_PassandoParametroCorreto_RetornaStatusCode200()
        {
            var delivery = new Delivery(1, 1, DateTime.Now);
            _saleService.Setup(mock => mock.GetDeliveryById(1)).Returns(delivery);
            var actual = _salesController.GetDeliveryById(1).Result;
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetDeliveryById_PassandoParametroCorretoPoremSemRetorno_RetornaStatusCode204NoContent()
        {
            _saleService.Setup(mock => mock.GetDeliveryById(1)).Returns(value: null);
            var actual = _salesController.GetDeliveryById(1).Result;
            Assert.IsType<NoContentResult>(actual);
        }
    }
}
