using EFCoreCommon.Model;
using Microsoft.AspNetCore.Mvc;
using TuyenDanQuan.Models;
using TuyenDanQuan.Service;

namespace TuyenDanQuan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // GET /Unit
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var units = await _unitService.GetAllAsync();
            return Ok(units);
        }

        // GET /Unit/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var unit = await _unitService.GetByIdAsync(id);
            if (unit == null) return NotFound();
            return Ok(unit);
        }

        // POST /Unit
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUnitDto dto)
        {
            var created = await _unitService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT /Unit/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUnitDto dto)
        {
            var updated = await _unitService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE /Unit/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _unitService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
