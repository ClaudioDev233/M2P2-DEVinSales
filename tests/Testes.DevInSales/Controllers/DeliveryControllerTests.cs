using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Api.Controllers;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Testes.DevInSales.Controllers
{
    public class DeliveryControllerTests
    {
        private readonly Mock<IDeliveryService> _deliveryService;
        private readonly DeliveryController _deliveryController;
        public DeliveryControllerTests(){
            _deliveryService = new Mock<IDeliveryService>();
            _deliveryController = new DeliveryController(_deliveryService.Object);
        }
        [Fact]
        public void GetDeliveryById_PassandoParametroCorreto_RetornaStatusCode200(){
            var deliveries = new List<Delivery>(){
                new Delivery(1 , 1 , DateTime.Now),
            };
            _deliveryService.Setup(mock => mock.GetBy(1, 1)).Returns(deliveries);
            var actual = _deliveryController.GetDelivery(1,1).Result;
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetDeliveryById_PassandoParametroCorretoPoremSemRetorno_RetornaStatusCode204NoContent(){
           
            _deliveryService.Setup(mock => mock.GetBy(1,1)).Returns(new List<Delivery>());
            var actual = _deliveryController.GetDelivery(1,1).Result;
            Assert.IsType<NoContentResult>(actual);
        }
    }
}