using System.Text.Json;
using Domain.Entities;

namespace Infrastructure.Models;

public static class CoordinatesMapper
{
    public static Coordinate MapToService(this DbCoordinates coords)
    {
        return coords == null
            ? new Coordinate()
            : new Coordinate
            {
                Id = coords.Id,
                ElementId = coords.ElementId,
                Coordinates = JsonSerializer.Deserialize<List<CoordinatesDto>>(coords.Coordinates)
            };
    }

    public static List<Coordinate> MapToService(this IEnumerable<DbCoordinates> coords)
    {
        return !coords.Any() ? new List<Coordinate>() : coords.Select(MapToService).ToList();
    }
}