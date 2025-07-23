using financeManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using financeManager.Application.Interfaces;

namespace financeManager.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IUserService service) : GenericController<User>(service)
{
    private readonly IUserService _userService = service;

    [HttpGet("by-email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        if (user == null) return NotFound();
        return Ok(user);
    }
}