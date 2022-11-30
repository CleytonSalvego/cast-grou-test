using Api.ViewModel;

namespace Api.Interfaces
{
    public interface ICepService
    {
        public Task<ResponseCepViewModel> Get(string cep);

        public string IsValid(string cep);
    }
}
