namespace Catalog.API.Products.GetProductsByCategory
{
    //public record GetProductsByCategoryRequest(string category);
    public class GetProductsByCategoryEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetProductsByCategoryQuery(category);
                var result = await sender.Send(query, cancellationToken);
                var response = result.Adapt<GetProductsByCategoryResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProductsByCategory")
                .WithDescription("Get products by Category")
                .WithSummary("Get products by Category")
                .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(statusCode: StatusCodes.Status400BadRequest);
        }
    }
    
}
