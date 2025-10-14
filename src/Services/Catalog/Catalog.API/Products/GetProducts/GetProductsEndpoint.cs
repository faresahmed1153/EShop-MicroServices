
namespace Catalog.API.Products.GetProducts
{
   // public record GetProductsRequest();

    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetProductsQuery();

                var result = await sender.Send(query, cancellationToken);

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
                .WithName("GetProducts")
                .WithDescription("Get products")
                .WithSummary("Get products")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(statusCode: StatusCodes.Status400BadRequest);
        }
    }
}
