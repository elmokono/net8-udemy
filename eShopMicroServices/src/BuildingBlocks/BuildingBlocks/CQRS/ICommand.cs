using MediatR;

namespace BuildingBlocks.CQRS
{
    //un comando que no devuelve nada
    public interface ICommand : ICommand<Unit>
    {

    }

    //un comando que devuelve una respuesta
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
