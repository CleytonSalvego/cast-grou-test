using Api.Interfaces;
using Api.ViewModel;

namespace Tests.APITests.Config
{
    internal class HttpServiceFake : IHttpService
    {
        public async Task<ResponseCepViewModel> Get(string cep, string uri)
        {
            if (cep != "01001000") return  new ResponseCepViewModel();

             var response = new ResponseCepViewModel
            {
                Cep = "01001-000",
                Logradouro = "Praça da Sé",
                Complemento = "lado ímpar",
                Bairro = "Sé",
                Localidade = "São Paulo",
                Uf = "SP",
                Ibge = 3550308,
                Gia = 1004,
                Ddd = 11,
                Siafi = 7107
            };

            return response;  
        }
    }
}
