using Microsoft.AspNetCore.Mvc;
using WebFinancial.Application.IServiceApplication;

namespace WebFinancial.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FaturaController : ControllerBase
{
    private readonly IFaturaService _faturaService;
    public FaturaController(IFaturaService faturaService)
    {
        _faturaService = faturaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFaturas()
    {
        try
        {
            var faturas = await _faturaService.GetAllFaturas();

            if (faturas == null) return NoContent();

            return Ok(faturas);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar faturas. Erro: {ex.Message}");
        }
    }

}
