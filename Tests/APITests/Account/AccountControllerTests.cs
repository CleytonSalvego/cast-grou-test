using Api.Controllers;
using Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Tests.APITests.Config;

namespace Tests.APITests.Account
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        [TestCategory("AccountController")]
        public async Task Should_Get_All_Accounts()
        {
            var repository = new AccountRepositoryFake();
            var controller = new AccountController(repository);

            var result = await controller.GetAll() as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(result.StatusCode, 200);

        }

        [TestMethod]
        [TestCategory("AccountController")]
        public async Task Should_Get_Account_ById()
        {
            var repository = new AccountRepositoryFake();
            var totalAccounts = repository.listAccount.Count;
            var account = new EditAccountViewModel() { Name = "Test", Description = "TestDescription" };
            var newAccount = await repository.Insert(account);
            Assert.IsTrue(repository.listAccount.Count > totalAccounts);

            var controller = new AccountController(repository);

            var result = await controller.GetById(newAccount.Id) as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(result.StatusCode, 200);

        }

        [TestMethod]
        [TestCategory("AccountController")]
        public async Task Should_Insert_New_Account()
        {
            var repository = new AccountRepositoryFake();
            var account = new EditAccountViewModel() { Name = "Test", Description = "TestDescription" };

            var controller = new AccountController(repository);

            var result = await controller.Insert(account) as CreatedResult;

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
            Assert.AreEqual(result.StatusCode, 201);

        }

        [TestMethod]
        [TestCategory("AccountController")]
        public async Task Should_Update_Account()
        {
            var repository = new AccountRepositoryFake();
            var account = await repository.GetByName("Test02");
            var updatedAccount = new EditAccountViewModel() { Name = "TestUpdated", Description = "TestDescriptionUpdated" };
            var controller = new AccountController(repository);

            var result = await controller.Update(account.Id, updatedAccount) as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(result.StatusCode, 200);

        }

        [TestMethod]
        [TestCategory("AccountController")]
        public async Task Should_Delete_Account()
        {
            var repository = new AccountRepositoryFake();
            var account = await repository.GetByName("Test05");
            var controller = new AccountController(repository);

            var result = await controller.Delete(account.Id) as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(result.StatusCode, 200);

        }
    }
}
