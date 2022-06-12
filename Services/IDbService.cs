using Microsoft.AspNetCore.Mvc;
using Zad7.Models;
using Zad7.Models.DTO;

namespace Zad7.Services;

public interface IDbService
{
    Task<IEnumerable<SomeSortOfTrip>> GetTrips();
    Task RemoveClient(int id);
    Task AssignClientToTrip(int idTrip, AssignTripDTO assignTripDto);
}