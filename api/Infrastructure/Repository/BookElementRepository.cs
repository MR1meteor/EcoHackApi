using Application.DTO;
using Application.Services.Models;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Scripts.BookElement;

namespace Infrastructure.Repository;

public class BookElementRepository(IDapperContext dapperContext) : IBookElementRepository
{
    public async Task<BookElement?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresBookElement.GetById, new { Id = id });
        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public async Task<List<BookElement>> GetAllByTypeAsync(BookElementType type)
    {
        var queryObject = new QueryObject(PostgresBookElement.GetAllByType, new { Type = (int)type });
        return await dapperContext.ListOrEmpty<BookElement>(queryObject) ?? new List<BookElement>();
    }

    public async Task<List<BookElement>> SearchByNameAsync(string name)
    {
        var queryObject = new QueryObject(PostgresBookElement.SearchByName, new { NameSearch = $"%{name}%" });
        return await dapperContext.ListOrEmpty<BookElement>(queryObject) ?? new List<BookElement>();
    }

    public async Task<int> CreateAsync(BookElementDbCreate data)
    {
        var query = new QueryObject(PostgresBookElement.Insert, data);
        return await dapperContext.CommandWithResponse<int>(query);
    }

    public Task<BookElement> UpdateAsync(int id, BookElementDbUpdate data)
    {
        var parameters = new
        {
            Id = id,
            Type = data.Type,
            Name = data.Name,
            Description = data.Description,
            Reason = data.Reason,
            Population = data.Population,
            Family = data.Family,
            Appearance = data.Appearance,
            Behavior = data.Behavior,
            Nutrition = data.Nutrition
        };
        
        var query = new QueryObject(PostgresBookElement.Update, parameters);
        
        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(PostgresBookElement.Delete, new { Id = id });
        await dapperContext.Command<BookElement>(query);
    }

    public async Task<List<BookElement>> GetAll()
    {
        var query = new QueryObject(PostgresBookElement.GetAll, new { });
        return await dapperContext.ListOrEmpty<BookElement>(query);
    }
}