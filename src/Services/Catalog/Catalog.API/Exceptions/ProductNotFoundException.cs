using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException()
            : base("Product was not found.")
        {
        }
    }
}
