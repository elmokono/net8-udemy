using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    /*
                +----------------------------+
                |    CQRS Handler using      |
                |   Repository Classes       |
                +----------------------------+
                            |
                +----------------------+
                |  IRequest<Result>     |
                +----------------------+
                            |
    +------------+    +----------------+    +------------+
    |  Command   | -> |   Repository   | -> |   Result   |
    |   Query    |    |     (calls     |    |            |
    |            |    |      DB)       |    |            |
    +------------+    +----------------+    +------------+
                            |
                        +----+
                        | DB |
                        +----+

    // CQRS usando MediatR:
    // - Command o Query implementan IRequest<Result>
    // - Handler llama al Repository
    // - Repository accede al DB
    // - Resultado se devuelve al caller
    */

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
