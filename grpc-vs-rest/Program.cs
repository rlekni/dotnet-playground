using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

// app.UseRouting();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapGet("/", async context =>
//     {
//         var endpointDataSource = context
//             .RequestServices.GetRequiredService<EndpointDataSource>();
//         await context.Response.WriteAsJsonAsync(new
//         {
//             results = endpointDataSource
//                 .Endpoints
//                 .OfType<RouteEndpoint>()
//                 .Where(e => e.DisplayName?.StartsWith("gRPC") == true)
//                 .Select(e => new
//                 {
//                     name = e.DisplayName, 
//                     pattern = e.RoutePattern.RawText,
//                     order = e.Order
//                 })
//                 .ToList()
//         });
//     });
//     endpoints.MapGrpcService<GreeterService>();
// });
app.Run();
