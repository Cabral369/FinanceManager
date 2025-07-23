using financeManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financeManager.API.Controllers;

[ApiController]
public class GenericController<T>(IGenericService<T> service) : ControllerBase where T : class
{
    protected readonly IGenericService<T> _service = service;

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);

        if (entity == null) return NotFound();

        return Ok(entity);
    }

    [HttpGet("get-all")]
    public virtual async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();

        if (entities is null) return NotFound();

        return Ok(entities);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create(T entity)
    {
        var createdEntity = await _service.AddAsync(entity);

        return Ok(createdEntity);
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(int id, T entity)
    {
        var response = await _service.GetByIdAsync(id);

        if (response is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var entity = await _service.GetByIdAsync(id);

        if (entity?.Data == null) return NotFound();

        await _service.DeleteAsync(entity.Data);

        return NoContent();
    }
}