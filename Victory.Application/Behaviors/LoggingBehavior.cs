namespace Victory.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        string requestName = typeof(TRequest).Name;

        Log.Information(messageTemplate: "Request: {Name} {@Request}", requestName, request);

        TResponse response = await next();

        return response;
    }
}