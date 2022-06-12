using Microsoft.AspNetCore.Mvc;
using Zad7.Models;
using Zad7.Services;

namespace Zad7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController
{
    private readonly IDbService _dbService;

    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveClient(int id)
    {
        await _dbService.RemoveClient(id);
        return Ok("Client deleted");
    }
}