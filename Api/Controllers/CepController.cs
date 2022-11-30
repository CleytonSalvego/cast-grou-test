using Api.Interfaces;
using Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("v1/ceps/{cep}")]
        public async Task<ActionResult> Get(
            [FromRoute] string cep)
        {
            var fieldCep = new CepViewModel { Cep = cep };
            var cepFormated = _cepService.IsValid(fieldCep.Cep);
            if (cepFormated == "") 
                return BadRequest(new ResultViewModel<string>("CEP inválido ou em branco"));

            var data = await _cepService.Get(cepFormated);
            return Ok(new ResultViewModel<ResponseCepViewModel>(data));
        }
    }
}
