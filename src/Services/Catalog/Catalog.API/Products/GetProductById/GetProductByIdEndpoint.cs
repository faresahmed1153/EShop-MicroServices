﻿
namespace Catalog.API.Products.GetProductById
{
   // public record GetProductByIdRequest(Guid ProductId);

    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetProductByIdQuery(id);
                var result = await sender.Send(query, cancellationToken);
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProductById")
                .WithDescription("Get product by Id")
                .WithSummary("Get product by Id")
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(statusCode: StatusCodes.Status400BadRequest);
                
        }
    }
}
