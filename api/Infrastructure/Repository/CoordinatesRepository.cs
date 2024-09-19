using Application.DTO;
using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;
using System.Text.Json;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Scripts.Coordinate;

namespace Infrastructure.Repository;

public class CoordinatesRepository(IDapperContext dapperContext) : ICoordinatesRepository
{
    public async Task<Coordinate?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresCoordinate.GetById, new { Id = id });
        return await dapperContext.FirstOrDefault<Coordinate>(queryObject);
    }

    public async Task<List<DbCoordinates>> GetAllByElementIdAsync(int elementId)
    {
        var queryObject = new QueryObject(PostgresCoordinate.GetByBookElement, new { ElementId = elementId });
        var result = await dapperContext.ListOrEmpty<DbCoordinates>(queryObject);
        return result;
    }

    public Task<DbCoordinates> CreateAsync(CoordinatesDbCreate data)
    {
        var parameters = new
        {
            ElementId = data.ElementId,
            Coordinates = JsonSerializer.Serialize(data.Coordinates)
        };
        
        var query = new QueryObject(PostgresCoordinate.Insert, parameters);
        return dapperContext.CommandWithResponse<DbCoordinates>(query);
    }

    public Task<DbCoordinates> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        var parameters = new
        {
            ElementId = data.ElementId,
            Coordinates = JsonSerializer.Serialize(data.Coordinates),
            Id = id
        };

        var query = new QueryObject(PostgresCoordinate.Update, parameters);
        return dapperContext.CommandWithResponse<DbCoordinates>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(PostgresCoordinate.Delete, new { Id = id });
        await dapperContext.Command<Coordinate>(query);
    }

    public async Task DeleteByBookElementAsync(int bookElementId)
    {
        var query = new QueryObject(PostgresCoordinate.DeleteByBookElement, new { BookElementId = bookElementId });
        await dapperContext.Command<int>(query);
    }
}