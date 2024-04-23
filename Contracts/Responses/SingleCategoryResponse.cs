namespace Contracts.Responses
{
    public record class SingleCategoryResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public bool IsActive { get; init; }
    }
}