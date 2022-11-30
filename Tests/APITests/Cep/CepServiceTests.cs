using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Tests.APITests.Config;

namespace Tests.APITests.CepService
{
    [TestClass]
    public class CepServiceTests
    {
        [TestMethod]
        [TestCategory("CepService")]
        public async Task Should_Get_Valid_Cep_Data()
        {
            var builder = WebApplication.CreateBuilder();
            var httpService = new HttpServiceFake();
            var cepService = new Api.Services.CepService(httpService, builder.Configuration);

            var result = await cepService.Get("01001000");
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Cep, "01001-000");
            Assert.AreEqual(result.Logradouro, "Praça da Sé");
            Assert.AreEqual(result.Complemento, "lado ímpar");
            Assert.AreEqual(result.Bairro, "Sé");
            Assert.AreEqual(result.Localidade, "São Paulo");
            Assert.AreEqual(result.Uf, "SP");
            Assert.AreEqual(result.Ibge, 3550308);
            Assert.AreEqual(result.Gia, 1004);
            Assert.AreEqual(result.Ddd, 11);
            Assert.AreEqual(result.Siafi, 7107);

        }

        [TestMethod]
        [TestCategory("CepService")]
        [DataRow("01-001-55")]
        [DataRow("01001-55")]
        [DataRow("0100155")]
        public void Should_Get_InValid_Cep(string cep)
        {
            var builder = WebApplication.CreateBuilder();
            var httpService = new HttpServiceFake();
            var cepService = new Api.Services.CepService(httpService, builder.Configuration);

            var result = cepService.IsValid(cep);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "");
            
        }

        [TestMethod]
        [TestCategory("CepService")]
        [DataRow("01-001-000")]
        [DataRow("01001-000")]
        [DataRow("01001000")]
        public void Should_Get_Valid_Cep(string cep)
        {
            var builder = WebApplication.CreateBuilder();
            var httpService = new HttpServiceFake();
            var cepService = new Api.Services.CepService(httpService, builder.Configuration);

            var result = cepService.IsValid(cep);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "01001000");

        }
    }
}