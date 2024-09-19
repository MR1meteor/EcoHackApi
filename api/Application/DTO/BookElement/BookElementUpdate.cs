using Application.Services.Models;
using Infrastructure.Models;

namespace Application.DTO.BookElement;

public class BookElementUpdate
{
    public BookElementType? Type { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Reason { get; set; }
    public string Population { get; set; }
    public string Family { get; set; }
    public string Appearance { get; set; }
    public string Behavior { get; set; }
    public string Nutrition { get; set; }
    public string Status { get; set; }
    public List<List<CoordinatesDto>> Coordinates { get; set; }
}