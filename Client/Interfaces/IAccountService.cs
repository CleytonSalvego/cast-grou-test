using Client.Models;

namespace Client.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountModel>> Get();

        Task<dynamic> Insert(EditAccountModel account);

        Task<dynamic> Update(Guid id, EditAccountModel account);

        Task<bool> Delete(string id);   
    }
}
