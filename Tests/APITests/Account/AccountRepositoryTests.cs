using Api.Model;
using Api.ViewModel;
using Tests.APITests.Config;

namespace Tests.APITests.Account
{
    [TestClass]
    public class AccountRepositoryTests
    {
        [TestMethod]
        [TestCategory("AccountService")]
        public async Task Should_Get_All_Data()
        {
            var repository = new AccountRepositoryFake();
            var listAccount = await repository.GetAll();
            Assert.AreEqual(listAccount.Count, 6);

        }

        [TestMethod]
        [TestCategory("AccountService")]
        public async Task Should_Get_Account_ByName()
        {
            var repository = new AccountRepositoryFake();
            var account = await repository.GetByName("Test04");
            Assert.AreEqual(account.Name, "Test04");
            Assert.AreEqual(account.Description, "TestDescription04");
        }

        [TestMethod]
        [TestCategory("AccountService")]
        public async Task Should_Insert_New_Account()
        {
            var repository = new AccountRepositoryFake();
            var totalAccounts = repository.listAccount.Count;
            var account = new EditAccountViewModel() { Name = "Test", Description = "TestDescription"};
            await repository.Insert(account);
            Assert.IsTrue(repository.listAccount.Count > totalAccounts);
        }

        [TestMethod]
        [TestCategory("AccountService")]
        public async Task Should_Update_Account()
        {
            var repository = new AccountRepositoryFake();
            var totalAccounts = repository.listAccount.Count;
            var account = await repository.GetByName("Test05");
            
            var updatedAccount = new EditAccountViewModel { Name = "TestUpdated", Description = "DescriptionUpdated" };
            await repository.Update(account.Id, updatedAccount);
            
            var Index = repository.listAccount.FindIndex(x => x.Id == account.Id);
            Assert.IsTrue(repository.listAccount[Index].Name == "TestUpdated");
            Assert.IsTrue(repository.listAccount[Index].Description == "DescriptionUpdated");
        }

        [TestMethod]
        [TestCategory("AccountService")]
        public async Task Should_Delete_Account()
        {
            var repository = new AccountRepositoryFake();
            var totalAccounts = repository.listAccount.Count;

            var account = await repository.GetByName("Test06");
            await repository.Delete(account.Id);
            
            Assert.IsTrue(repository.listAccount.Count < totalAccounts);

        }
    }
}
