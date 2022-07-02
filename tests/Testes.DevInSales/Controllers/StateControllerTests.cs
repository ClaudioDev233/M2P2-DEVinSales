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
    public class StateControllerTests
    {
        private readonly Mock<IStateService> _stateService;
        private readonly StateController _stateController;

        public StateControllerTests()
        {
            _stateService = new Mock<IStateService>();
            _stateController = new StateController(_stateService.Object);
        }

        [Fact]
        public void GetAll_RetornaOk200()
        {
            var listStates = new List<ReadState>() { new ReadState(), };
            _stateService.Setup(mock => mock.GetAll("Estado")).Returns(listStates);

            var actual = (_stateController.GetAll("Estado"));
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetAll_RetornaNoContent()
        {
            var listStates = new List<ReadState>();
            _stateService.Setup(mock => mock.GetAll("Estado")).Returns(listStates);

            var actual = _stateController.GetAll("Estado");
            Assert.IsType<NoContentResult>(actual);
        }

        [Fact]
        public void GetByStateId_PassandoStateIdValido_RetornaStatusCode200()
        {
            var state = new ReadState();
            _stateService.Setup(mock => mock.GetById(1)).Returns(state);
            var actual = _stateController.GetByStateId(1);
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void GetByStateId_PassandoStateIdInvalido_RetornaNotFound()
        {
            _stateService.Setup(mock => mock.GetById(1));
            var actual = _stateController.GetByStateId(1);
            Assert.IsType<NotFoundResult>(actual);
        }
    }
}
