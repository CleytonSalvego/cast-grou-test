using Api.Interfaces;
using Api.Model;
using Api.ViewModel;

namespace Tests.APITests.Config
{
    internal class AccountRepositoryFake : IAccountRepository
    {

        public List<AccountModel> listAccount;

        public AccountRepositoryFake()
        {
            listAccount = new List<AccountModel>();
            listAccount .Add(new AccountModel() {Name = "Test01", Description = "TestDescription01"});
            listAccount .Add(new AccountModel() {Name = "Test02", Description = "TestDescription02"});
            listAccount .Add(new AccountModel() {Name = "Test03", Description = "TestDescription03"});
            listAccount .Add(new AccountModel() {Name = "Test04", Description = "TestDescription04"});
            listAccount .Add(new AccountModel() {Name = "Test05", Description = "TestDescription05"});
            listAccount .Add(new AccountModel() {Name = "Test06", Description = "TestDescription06"});
        }


        public async Task<List<AccountModel>> GetAll()
        {
            return listAccount;
        }

        public async Task<AccountModel> GetById(Guid id)
        {
            return listAccount.FirstOrDefault(x => x.Id == id);
        }

        public async Task<AccountModel> GetByName(string name)
        {
            return listAccount.FirstOrDefault(x => x.Name == name);
        }

        public async Task<AccountModel> Insert(EditAccountViewModel account)
        {
            var randomGenerator = new Random();
            var random = randomGenerator.Next(1,100);
            var newAccount = new AccountModel() { Name = $"{account.Name}{random}", Description = $"{account.Description}{random}" };
            listAccount.Add(newAccount);
            return newAccount;
        }

        public async Task<AccountModel> Update(Guid id, EditAccountViewModel account)
        {
            var index = listAccount.FindIndex(t => t.Id == id);

            if (index == null) return null;
         
            listAccount[index].Name = account.Name;
            listAccount[index].Description = account.Description;

            return listAccount.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> Delete(Guid id)
        {
            var index = listAccount.FindIndex(t => t.Id == id);

            if (index == null) return false;

            listAccount.RemoveAt(index);
            return true;
        }

        public Task<ResponseCepViewModel> Get(string cep, string uri)
        {
            throw new NotImplementedException();
        }
    }
}
