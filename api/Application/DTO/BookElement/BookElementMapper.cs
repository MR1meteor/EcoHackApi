using Domain.Entities;
using Infrastructure.Models;

namespace Application.DTO.BookElement;

public static class BookElementMapper
{
    public static BookElementCreate MapToDefaultResponse(Domain.Entities.BookElement element)
    {
        return new BookElementCreate()
        {
            Type = element.Type,
            Name = element.Name,
            Description = element.Description,
        };
    }

    public static BookElementGet MapToGetResponse(this Domain.Entities.BookElement element, List<Coordinate> coords)
    {
        return element == null
            ? new BookElementGet()
            : new BookElementGet
            {
                Id = element.Id,
                Type = element.Type,
                Name = element.Name,
                Description = element.Description,
                Reason = element.Reason,
                Population = element.Population,
                Family = element.Family,
                Appearance = element.Appearance,
                Behavior = element.Behavior,
                Nutrition = element.Nutrition,
                Status = element.Status,
                Coordinates = coords.Select(coords => coords.Coordinates).ToList(),
                ImageUrl = element.ImageUrl
            };
    }
}