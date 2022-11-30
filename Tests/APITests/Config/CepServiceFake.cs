
using Api.Interfaces;
using Api.ViewModel;

namespace Tests.APITests.Config
{
    internal class CepServiceFake : ICepService
    {
        public async Task<ResponseCepViewModel> Get(string cep)
        {
            if (cep == null) new ResponseCepViewModel();

            return new ResponseCepViewModel
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
        }

        public string IsValid(string cep)
        {
            throw new NotImplementedException();
        }
    }
}
