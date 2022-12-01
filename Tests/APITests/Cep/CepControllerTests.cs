

using Api.Controllers;
using Api.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Tests.APITests.Config;

namespace Tests.APITests.CepService
{
    [TestClass]
    public class CepControllerTests
    {
        [TestMethod]
        [TestCategory("CepController")]
        [DataRow("01001000")]
        [DataRow("01-001-000")]
        [DataRow("01001-000")]
        public async Task Should_Get_Valid_Cep(string cep)
        {
            var builder = WebApplication.CreateBuilder();
            var httpService = new HttpServiceFake();
            var cepService = new Api.Services.CepService(httpService, builder.Configuration);
            var controller = new CepController(cepService);

            var result = await controller.Get(cep) as OkObjectResult;
            
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(result.StatusCode, 200);

        }

        [TestMethod]
        [TestCategory("CepController")]
        [DataRow("123-1234")]
        public async Task Should_Get_Error_Cep_Invalid(string cep)
        {
            var builder = WebApplication.CreateBuilder();
            var httpService = new HttpServiceFake();
            var cepService = new Api.Services.CepService(httpService, builder.Configuration);
            var controller = new CepController(cepService);

            var result = await controller.Get(cep) as BadRequestObjectResult;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual(result.StatusCode, 400);

        }

        [TestMethod]
        [TestCategory("CepController")]
        [DataRow("")]
        public async Task Should_Get_Error_Cep_Empty(string cep)
        {
            var fieldCep = new CepViewModel { Cep = cep };
            var builder = WebApplication.CreateBuilder();
            var httpService = new HttpServiceFake();
            var cepService = new Api.Services.CepService(httpService, builder.Configuration);
            var controller = new CepController(cepService);

            var result = await controller.Get(cep) as BadRequestObjectResult;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual(result.StatusCode, 400);

        }
    }
}
