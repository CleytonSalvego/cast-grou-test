using Api.Interfaces;
using Api.Model;
using Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("v1/accounts")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _accountRepository.GetAll();
            return Ok(new ResultViewModel<List<AccountModel>>(data));
        }

        [HttpGet("v1/accounts/{id}")]
        public async Task<ActionResult> GetById(
            [FromRoute] Guid id)
        {
            var data = await _accountRepository.GetById(id);
            return Ok(new ResultViewModel<AccountModel>(data));
        }

        [HttpPost("v1/accounts")]
        public async Task<ActionResult> Insert(
            [FromBody] EditAccountViewModel account)
        {
            if (!ModelState.IsValid) 
                return BadRequest(new ResultViewModel<AccountModel>("Dados enviados inválidos"));

            var existAccount = await _accountRepository.GetByName(account.Name);
            if (existAccount != null ) return StatusCode(422, "Esta conta já existe.");

            var data = await _accountRepository.Insert(account);
            return Created("", new ResultViewModel<AccountModel>(data));
        }

        [HttpPut("v1/accounts/{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] EditAccountViewModel account)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<AccountModel>("Dados enviados inválidos"));

            var data = await _accountRepository.Update(id, account);
            return Ok(new ResultViewModel<AccountModel>(data));
        }

        [HttpDelete("v1/accounts/{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] Guid id)
        {
            var data = await _accountRepository.Delete(id);

            if (!data) 
                return StatusCode(500, new ResultViewModel<AccountModel>("Não foi possível remover os dados."));

            return Ok("Dados removidos com sucesso");
        }

    }
}
