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
            var data = await _cepService.Get(cep);
            return Ok(new ResultViewModel<ResponseCepViewModel>(data));
        }
    }
}
