using Microsoft.AspNetCore.Mvc;
using Zad7.Models.DTO;
using Zad7.Services;

namespace Zad7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : Controller
{
    private readonly IDbService _dbService;

    public TripsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await _dbService.GetTrips();
        return Ok(trips);
    }

    [HttpPost]
    [Route("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, AssignTripDTO assignTripDto)
    {
        // _dbService.AssignClientToTrip(idTrip, assignTripDto);
    }
}