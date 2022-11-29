using Api.ViewModel;

namespace Api.Interfaces
{
    public interface IHttpService
    {
        Task<ResponseCepViewModel> Get(string cep, string uri);

    }
}
