using Client.Interfaces;
using Client.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AccountService(
            HttpClient httpClient, 
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
    


        public async  Task<List<AccountModel>> Get()
        {

            var url = $"{_configuration.GetSection("UriAPi").GetSection("uri").Value}/accounts";
            var client = new RestClient(url);
            var request = new RestRequest(url);
            var response = await client.GetAsync(request);
            var result = JsonConvert.DeserializeObject<ResponseAccountModel> (response.Content);

            var list = new List<AccountModel>();
            if (result.data.Count > 0)
            {
                foreach (var account in result.data)
                {
                    list.Add(new AccountModel() { Id = account.Id, Name= account.Name, Description = account.Description});
                }
            }

            return list;
        }

        public async Task<dynamic> Insert(EditAccountModel account)
        {
            var url = $"{_configuration.GetSection("UriAPi").GetSection("uri").Value}/accounts";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new EditAccountModel
            {
                Name = account.Name,
                Description = account.Description
            };
            var bodyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyy, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            if ((int)response.StatusCode != StatusCodes.Status201Created)
                return null;
                
            var result = JsonConvert.DeserializeObject<ResponseAccountModel>(response.Content);
            return result;
        }

        public async Task<dynamic> Update(Guid id, EditAccountModel account)
        {
            var url = $"{_configuration.GetSection("UriAPi").GetSection("uri").Value}/accounts/{id}";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            var bodyy = JsonConvert.SerializeObject(account);
            request.AddBody(bodyy, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            if ((int)response.StatusCode != StatusCodes.Status200OK)
                return null;

            var result = JsonConvert.DeserializeObject<ResponseAccountModel>(response.Content);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var url = $"{_configuration.GetSection("UriAPi").GetSection("uri").Value}/accounts/{id}";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Delete);
            RestResponse response = await client.ExecuteAsync(request);
            if ((int)response.StatusCode == StatusCodes.Status200OK)
                return true;

            return false;
        }

    }
}
