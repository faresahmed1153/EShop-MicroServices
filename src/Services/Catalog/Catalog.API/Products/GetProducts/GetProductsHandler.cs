
namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery: IQuery<GetProductsResult>
    {
    }

    public record GetProductsResult(IEnumerable<Product> Products);



    public class GetQueryProductsQueryHandler(IDocumentSession session,ILogger<GetQueryProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductsQuery @{Query}", query);

            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
