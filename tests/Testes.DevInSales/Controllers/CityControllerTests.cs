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
    public class CityControllerTests
    {
        private readonly Mock<ICityService> _cityService;
        private readonly Mock<IStateService> _stateService;
        private readonly CityController _cityController;

        public CityControllerTests()
        {
            _stateService = new Mock<IStateService>();
            _cityService = new Mock<ICityService>();
            _cityController = new CityController(_stateService.Object, _cityService.Object);
        }

        [Fact]
        public void GetCityByStateId_PassandoParametrosInvalidos_RetornaNotFound()
        {
            _cityService.Setup(mock => mock.GetAll(1, "teste"));
            var actual = _cityController.GetCityByStateId(1, "teste");
            Assert.IsType<NotFoundResult>(actual);
        }

        [Fact]
        public void GetCityId_PassandoParametrosInvalidos_RetornaNotFound()
        {
            _cityService.Setup(mock => mock.GetById(1));
            var actual = _cityController.GetCityById(1, 1);
            Assert.IsType<NotFoundResult>(actual);
        }
    }
}
