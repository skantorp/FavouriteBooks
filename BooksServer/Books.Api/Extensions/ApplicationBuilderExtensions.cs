using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Books.Api.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						logger.LogError($"Error: {contextFeature.Error}");
						await context.Response.WriteAsync(JsonSerializer.Serialize(new
						{
							Message = "Internal server error",
							StatusCode = (int)HttpStatusCode.InternalServerError
						}));
					}
				});
			});
		}
	}
}
