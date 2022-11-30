using Api.Interfaces;
using Api.ViewModel;
using System.Text.RegularExpressions;

namespace Api.Services
{
    public class CepService: ICepService
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;

        public CepService(
            IHttpService httpService,
            IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }

        public Task<ResponseCepViewModel> Get(string cep)
        {
            return _httpService.Get(cep, _configuration.GetSection("CepSettings").GetSection("uri").Value);
        }

        public string IsValid(string cep)
        {
            var formatedCep = FormatCep(cep);
            if (formatedCep.Length != 8) return "";
            
            return formatedCep;
        }

        private string FormatCep(string cep)
        {
            return Regex.Replace(cep, "[^0-9]+", "");
        }
    }
}
