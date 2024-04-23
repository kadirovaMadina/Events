namespace Contracts.Responses
{
    public record class GetAllCategoriesResponse
    {
        public IEnumerable<SingleCategoryResponse> Items { get; init; } = Enumerable.Empty<SingleCategoryResponse>();
    }
}
