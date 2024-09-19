using Application.DTO;
using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface ICoordinatesRepository
{
    public Task<Coordinate?> GetByIdAsync(int id);
    public Task<List<DbCoordinates>> GetAllByElementIdAsync(int elementId);
    public Task<DbCoordinates> CreateAsync(CoordinatesDbCreate data);
    public Task<DbCoordinates> UpdateAsync(int id, CoordinatesDbUpdate data);
    public Task DeleteAsync(int id);
    public Task DeleteByBookElementAsync(int bookElementId);
}