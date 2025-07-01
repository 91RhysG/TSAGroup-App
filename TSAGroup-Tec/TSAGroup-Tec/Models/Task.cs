namespace TSAGroup_Tec.Models;

public record Task
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public required DateTime CreatedAt { get; set; }
}