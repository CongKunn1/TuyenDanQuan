using Microsoft.AspNetCore.Mvc;
using TuyenDanQuan.Models;
using TuyenDanQuan.Service;

[ApiController]
[Route("api/[controller]")]
public class CitizenController : ControllerBase
{
    private readonly ICitizenService _citizenService;

    public CitizenController(ICitizenService citizenService)
    {
        _citizenService = citizenService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCitizenDto dto)
    {
        var result = await _citizenService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _citizenService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _citizenService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateCitizenDto dto)
    {
        var result = await _citizenService.UpdateAsync(id, dto);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _citizenService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] CitizenFilterDto filter)
    {
        var result = await _citizenService.FilterAsync(filter);
        return Ok(result);
    }
    [HttpPost("bulk")]
    public async Task<IActionResult> CreateBulkAsync([FromBody] List<CreateCitizenDto> dtos)
    {
        await _citizenService.CreateBulkAsync(dtos);
        return Ok();
    }
}


