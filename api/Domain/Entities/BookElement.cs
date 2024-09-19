namespace Domain.Entities;

using Application.Services.Models;

public class BookElement
{
    public int Id { get; set; }
    public BookElementType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Reason { get; set; }
    public string Population { get; set; }
    public string Family { get; set; }
    public string Appearance { get; set; }
    public string Behavior { get; set; }
    public string Nutrition { get; set; }
    public string Status { get; set; }
    public string ImageUrl { get; set; }
}