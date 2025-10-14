namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(string Category):IQuery<GetProductsByCategoryResponse>;

    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResponse>
    {
        public async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductsByCategoryRequest {@Query}", query);

            var products= await session.Query<Product>()
                .Where(p => p.Category.Contains(query.Category))
                .ToListAsync(cancellationToken);

            return new GetProductsByCategoryResponse(products);

        }
    }
}
