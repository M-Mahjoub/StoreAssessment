﻿using MediatR;

namespace Store.Application.Behaviours
{
    public class UnhandlerExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        //private readonly ILogger _logger;
        public UnhandlerExceptionBehaviour()
        {
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                //_logger.LogError(ex, "Application Request: Unhandled Exception.", requestName, request);
                throw;
            }
        }
    }
}
