﻿using Application.DTO;
using Application.DTO.BookElement;
using Application.Services.Models;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class BookElementService(IBookElementRepository bookElementRepository, ICoordinatesRepository coordinatesRepository) : IBookElementService
{
    public async Task CreateAsync(BookElementCreate data)
    {
        var bookElementId = await bookElementRepository.CreateAsync(new BookElementDbCreate
        {
            Type = data.Type,
            Name = data.Name,
            Description = data.Description,
            Reason = data.Reason,
            Population = data.Population,
            Family = data.Family,
            Appearance = data.Appearance,
            Behavior = data.Behavior,
            Nutrition = data.Nutrition,
            Status = data.Status
        });

        foreach (var coords in data.Coordinates)
        {
            var coordsDbCreate = new CoordinatesDbCreate
            {
                ElementId = bookElementId,
                Coordinates = coords
            };

            await coordinatesRepository.CreateAsync(coordsDbCreate);
        }
    }

    public async Task<BookElement> UpdateAsync(int id, BookElementUpdate data)
    {
        var bookElement = await bookElementRepository.UpdateAsync(id, new BookElementDbUpdate
        {
            Type = data.Type,
            Name = data.Name,
            Description = data.Description,
            Reason = data.Reason,
            Population = data.Population,
            Family = data.Family,
            Appearance = data.Appearance,
            Behavior = data.Behavior,
            Nutrition = data.Nutrition,
            Status = data.Status
        });
        
        await coordinatesRepository.DeleteByBookElementAsync(bookElement.Id);
        
        foreach (var coords in data.Coordinates)
        {
            var coordsDbCreate = new CoordinatesDbCreate
            {
                ElementId = bookElement.Id,
                Coordinates = coords
            };

            await coordinatesRepository.CreateAsync(coordsDbCreate);
        }

        return bookElement;
    }

    public Task DeleteAsync(int id) => 
        bookElementRepository.DeleteAsync(id);

    public Task<List<BookElement>> GetAllByType(BookElementType type) => 
        bookElementRepository.GetAllByTypeAsync(type);

    public async Task<BookElementGet> GetById(int id)
    {
        var bookElementDb = await bookElementRepository.GetByIdAsync(id);
        var bookElementCoords = await coordinatesRepository.GetAllByElementIdAsync(id);

        return bookElementDb.MapToGetResponse(bookElementCoords.MapToService());
    }

    public async Task<List<BookElement>> SearchByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new List<BookElement>();
        }

        return await bookElementRepository.SearchByNameAsync(name);
    }

    public async Task<List<BookElementGet>> GetAll()
    {
        var bookElements = await bookElementRepository.GetAll();
        var result = new List<BookElementGet>();
        foreach (var bookElement in bookElements)
        {
            var coords = await coordinatesRepository.GetAllByElementIdAsync(bookElement.Id);
            result.Add(bookElement.MapToGetResponse(coords.MapToService()));
        }

        return result;
    }
}