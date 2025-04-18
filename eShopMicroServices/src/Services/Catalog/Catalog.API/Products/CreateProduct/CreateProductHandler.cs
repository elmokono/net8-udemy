using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand
        (string Name, List<string> Categories, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // business logic to create product in db here..
            var product = new Product
            {
                Categories = command.Categories,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Name = command.Name,
                Price = command.Price,
            };

            // save to db

            //return guid of new product
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
