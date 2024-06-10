using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly CorreiosService _correiosService;

    public AddressController(CorreiosService correiosService)
    {
        _correiosService = correiosService;
    }

    [HttpGet("{zipCode}")]
    public async Task<IActionResult> GetAddress(string zipCode)
    {
        var address = await _correiosService.GetAddressByZipCode(zipCode);
        return Ok(address);
    }
}

