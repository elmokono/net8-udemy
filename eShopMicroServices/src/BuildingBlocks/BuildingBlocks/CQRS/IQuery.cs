using MediatR;

namespace BuildingBlocks.CQRS
{
    //un query que devuelve algo (distinto de null)
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {

    }
}
