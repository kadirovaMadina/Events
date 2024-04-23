namespace Contracts.Requests
{
    public record class CreateCategoryRequest
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
        public bool IsActive { get; init; }
    }
}