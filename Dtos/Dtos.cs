namespace Play.Catalog.Service.Dtos;

public record ItemDto(GuiId Id, string Name, string Description, decimal Price, DateTimeOffset CreateAdte);
public record CreateItemDto(string Name, string Description, decimal Price)
public record UpdateItemDto(string Name, string Description, decimal Price)