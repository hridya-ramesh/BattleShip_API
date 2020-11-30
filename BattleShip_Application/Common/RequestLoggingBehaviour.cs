using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip_Application.Common
{
    public class RequestLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TResponse : notnull
    {
        private static string RequestTypeName => typeof(TRequest).Name;

        private readonly ILogger _logger;

        public RequestLoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var serialiazedRequest = string.Empty;
            try
            {
                serialiazedRequest = JsonConvert.SerializeObject(request);
                _logger.LogInformation("Request prepared: {RequestTypeName} {@Request}", request.GetType().Name, serialiazedRequest);
                var result = await next();
                _logger.LogInformation("Response : {ResponseTypeName} {@Response}", result.GetType().Name, JsonConvert.SerializeObject(result));
                return result;
            }
            catch (Exception ex)
            {
                HandleException(LogLevel.Error, ex, serialiazedRequest);
                throw;
            }
        }


        private void HandleException(LogLevel level, Exception exception, string request)
        {
            const string logMessageFormat = "Exception on request: {RequestTypeName} {Request}";

            switch (level)
            {
                case LogLevel.Information:
                    _logger.LogInformation(exception, logMessageFormat, RequestTypeName, request);
                    break;

                case LogLevel.Error:
                    _logger.LogError(exception, logMessageFormat, RequestTypeName, request);
                    break;

                case LogLevel.Warning:
                    _logger.LogWarning(exception, logMessageFormat, RequestTypeName, request);
                    break;

                default:
                    throw new NotImplementedException("Log level not found");
            }
        }
    }
}
