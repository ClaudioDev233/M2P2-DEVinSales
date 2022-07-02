using DevInSales.Api.Controllers;
using DevInSales.Api.Dtos;
using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Testes.DevInSales.Controllers
{
    public class AddressControllerTests
    {
        private readonly Mock<IAddressService> _addressService;
        private readonly Mock<IStateService> _stateService;
        private readonly Mock<ICityService> _cityService;

        private readonly AddressController _controller;

        public AddressControllerTests()
        {
            _addressService = new Mock<IAddressService>();
            _stateService = new Mock<IStateService>();
            _cityService = new Mock<ICityService>();

            _controller = new AddressController(
                _addressService.Object,
                _stateService.Object,
                _cityService.Object
            );
        }

        [Fact]
        public void GetAll_RetornaOk200()
        {
            var expected = new List<ReadAddress>() { new ReadAddress(), };
            _addressService.Setup(mock => mock.GetAll(1, 1, "rua", "cepTeste")).Returns(expected);

            var actual = (_controller.GetAll(1, 1, "rua", "cepTeste"));
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetAll_RetornaNoContent()
        {
            var expected = new List<ReadAddress>();
            _addressService.Setup(mock => mock.GetAll(null, null, null, null)).Returns(expected);

            var actual = _controller.GetAll(null, null, null, null);
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void Delete_PassandoIdInvalido_RetornaNotFound()
        {
            var address = new Address("Rua", "72877231", 213, "Casa", 1);
            _addressService.Setup(mock => mock.Delete(address));
            var actual = _controller.DeleteAddress(1);
            Assert.IsType<NotFoundResult>(actual);
        }

        [Fact]
        public void Delete_PassandoIdValido_RetornaNoContent()
        {
            var address = new Address("Rua", "72877231", 213, "Casa", 1);
            _addressService.Setup(mock => mock.GetById(1)).Returns(address);
            _addressService.Setup(mock => mock.Delete(address));
            var actual = _controller.DeleteAddress(1);
            Assert.IsType<NoContentResult>(actual);
        }
    }
}
