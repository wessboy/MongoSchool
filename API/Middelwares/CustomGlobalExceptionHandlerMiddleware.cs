using API.ValueObjects;
using Microsoft.AspNetCore.Http;
using System.Net;
using ZstdSharp.Unsafe;

namespace API.Middelwares;
    public class CustomGlobalExceptionHandlerMiddleware
    {
	    private readonly ILogger _logger;
	private readonly RequestDelegate _next;
		public CustomGlobalExceptionHandlerMiddleware(RequestDelegate next,ILogger<CustomGlobalExceptionHandlerMiddleware> logger)
		{
			_logger = logger;	
			_next = next;
		}
        public async Task Invoke(HttpContext context)
		{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{

			_logger.LogError($"Unhandled Exception:{ex}");

			await HandleExceptionAsync(context, ex);
			
		}
        }

	    private async Task HandleExceptionAsync(HttpContext context,Exception exception)
		{
		   context.Response.ContentType = "application/json";
		   context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			await context.Response.WriteAsync(new ErrorDetails ()
			{ 
			     StatusCode = context.Response.StatusCode,
				 Message = "Internal Server Error From CustomGlobalExceptionHandlerMiddleware"
            }.ToString());
		}
    }

