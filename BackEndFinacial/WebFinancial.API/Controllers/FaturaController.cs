using Microsoft.AspNetCore.Mvc;
using WebFinancial.Application.Dtos;
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFaturaById(int id)
    {
        try
        {
            var fatura = await _faturaService.GetFaturaById(id);

            if(fatura == null) return NoContent();

            return Ok(fatura);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar fatura. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddFatura(FaturaDto model)
    {
        try
        {
            var fatura = await _faturaService.AddFatura(model);

            if (fatura == null) return NoContent();

            return Ok(fatura);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar fatura. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateFatura(int id, FaturaDto model)
    {
        try
        {
            var fatura = await _faturaService.UpdateFatura(id, model);

            if (fatura == null) return NoContent();

            return Ok(fatura);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar fatura. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFatura(int id)
    {
        try
        {
            var fatura = await _faturaService.DeleteFatura(id);

            if (!fatura)
                throw new Exception("Ocorreu um erro não específico ao tentar deletar Fatura.");

            return Ok(new { message = "Fatura deletada"});

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar fatura. Erro: {ex.Message}");
        }
    }

}
