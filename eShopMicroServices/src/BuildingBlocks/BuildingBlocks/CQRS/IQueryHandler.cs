using MediatR;

namespace BuildingBlocks.CQRS
{
    //un query que devuelve una respuesta
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    {

    }
}
