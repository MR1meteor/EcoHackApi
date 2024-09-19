using System.Text.Json;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class CoordinatesService(ICoordinatesRepository coordinatesRepository) : ICoordinatesService
{
    public async Task<Coordinate> CreateAsync(CoordinatesDbCreate data)
    {
        var dbCoords = await coordinatesRepository.CreateAsync(data);
        return new Coordinate
        {
            Id = dbCoords.Id,
            ElementId = dbCoords.ElementId,
            Coordinates = JsonSerializer.Deserialize<List<CoordinatesDto>>(dbCoords.Coordinates)
        };
    }

    public async Task<Coordinate> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        var upd = await coordinatesRepository.UpdateAsync(id, data);
        var coord = new Coordinate()
        {
            Id = upd.Id,
            ElementId = upd.ElementId,
            Coordinates = JsonSerializer.Deserialize<List<CoordinatesDto>>(upd.Coordinates)
        };
        return coord;
    }

    public async Task DeleteAsync(int id)
    {
        await coordinatesRepository.DeleteAsync(id);
    }

    public async Task<List<Coordinate>> GetAllByElementId(int id)
    {
        // return await coordinatesRepository.GetAllByElementIdAsync(id);
        return new List<Coordinate>();
    }
    
    public async Task<Coordinate?> GetById(int id)
    {
        return await coordinatesRepository.GetByIdAsync(id);
    }
}