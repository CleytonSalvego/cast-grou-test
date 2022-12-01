using Api.Interfaces;
using Api.ViewModel;
using Newtonsoft.Json;
using RestSharp;


namespace Api.Services
{
    public class HttpRestSharpService : IHttpService
    {
        public async Task<ResponseCepViewModel> Get(string cep, string uri)
        {
            var url = $"{uri}/{cep}/json";
            var client = new RestClient(url);
            var request = new RestRequest(url);
            var response = await client.GetAsync(request);
            var result = JsonConvert.DeserializeObject<ResponseCepViewModel>(response.Content);
           

            return result;

        }
    }
}
