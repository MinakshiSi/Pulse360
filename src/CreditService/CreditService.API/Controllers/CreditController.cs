using CreditService.Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CreditController : ControllerBase
{
    private readonly ICreditService _creditService;

    public CreditController(ICreditService creditService)
    {
        _creditService = creditService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCreditScore(Guid userId)
    {
        var score = await _creditService.GetCreditScoreAsync(userId);
        return Ok(score);
    }
}
