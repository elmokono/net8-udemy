using MediatR;

namespace BuildingBlocks.CQRS
{
    //un comando que no devuelve nada
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit> //TCommand tiene que implementar ICommand<void> Unit es como un void
    {

    }

    //un comando que devuelve una respuesta
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse> //TCommand tiene que implementar ICommand<TResponse>
        where TResponse : notnull
    {

    }
}
