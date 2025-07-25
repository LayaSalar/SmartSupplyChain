
using MediatR;

namespace BuildingBlocks.CQRS;

    public interface   IQueryhandler<TRequest, TResponse> : IRequestHandler <TRequest, TResponse>
    where TRequest : IQuery<TResponse>
    where TResponse : notnull 
    {
    }

