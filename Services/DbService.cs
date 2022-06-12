using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zad7.Models;
using Zad7.Models.DTO;

namespace Zad7.Services;

public class DbService : IDbService
{
    private readonly s20373Context _dbContext;

    public DbService(s20373Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<SomeSortOfTrip>> GetTrips()
    {
        return await _dbContext.Trips
            .Include(e => e.CountryTrips)
            .Include(e => e.ClientTrips)
            .Select(e => new SomeSortOfTrip
            {
                Name = e.Name,
                Description = e.Description,
                MaxPeople = e.MaxPeople,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                Countries = e.CountryTrips.Select(e => new SomeSortOfCountry(){ Name = e.IdCountryNavigation.Name }).ToList(),
                Clients = e.ClientTrips.Select(e => new SomeSortOfClient()
                {
                    FirstName = e.IdClientNavigation.FirstName,
                    LastName = e.IdClientNavigation.LastName
                }).ToList()
            })
            .OrderByDescending(e => e.DateFrom)
            .ToListAsync();
    }
    
    public async Task RemoveClient(int id)
    {
        var clientHasTrips = _dbContext.ClientTrips.Where(e => e.IdClient == id).FirstOrDefaultAsync();

        if (clientHasTrips is not null)
        {
            throw new Exception("Client cannot be deleted");
        }
        
        var client = new Client() { IdClient = id };
        _dbContext.Attach(client);
        _dbContext.Remove(client);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AssignClientToTrip(int idTrip, AssignTripDTO assignTripDto)
    {
        // var client = _dbContext.Clients.FirstOrDefault(e => e.IdClient == assignTripDto.IdClient);
        // if (client is null)
        // {
        //     var addClient = new Client()
        //     {
        //         FirstName = assignTripDto.FirstName,
        //         LastName = assignTripDto.LastName,
        //         Email = assignTripDto.Email,
        //         Pesel = assignTripDto.Pesel,
        //         Telephone = assignTripDto.Telephone
        //     };
        //     _dbContext.Add(addClient);
        // }
        //
        // var clientHasTrip = _dbContext.ClientTrips
        //     .FirstOrDefault(e => e.IdClient == assignTripDto.IdClient)

        
        
    }
}