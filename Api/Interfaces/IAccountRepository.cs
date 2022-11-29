using Api.Model;
using Api.ViewModel;

namespace Api.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountModel>> GetAll();

        Task<AccountModel> GetById(Guid id);

        Task<AccountModel> GetByName(string name);

        public Task<AccountModel> Insert(EditAccountViewModel account);

        public Task<AccountModel> Update(Guid id, EditAccountViewModel account);

        public Task<bool> Delete(Guid id);
    }
}
