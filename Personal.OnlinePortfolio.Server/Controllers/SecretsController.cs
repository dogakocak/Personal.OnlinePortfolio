using Microsoft.AspNetCore.Mvc;
using Personal.OnlinePortfolio.Server.Services;

namespace Personal.OnlinePortfolio.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecretsController : ControllerBase
    {
        private readonly IKeyVaultService _keyVaultService;

        public SecretsController(IKeyVaultService keyVaultService)
        {
            _keyVaultService = keyVaultService;
        }

        [HttpGet("{secretName}")]
        public async Task<IActionResult> GetSecret(string secretName)
        {
            try
            {
                string secretValue = await _keyVaultService.GetSecretAsync(secretName);
                return Ok(secretValue);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
