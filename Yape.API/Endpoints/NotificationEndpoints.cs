using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Yape.API;
using Yape.Application.DTOs;
using Yape.Application.Interfaces;
namespace Yape.API.Endpoints;

public static class NotificationEndpoints
{
    public static void MapNotificationEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Notification").WithTags(nameof(NotificationDto));

        group.MapPost("/notify", (NotificationDto request, INotificationService notificationService) =>
        {
            var response = notificationService.SendNotification(request);
            return Results.Ok(response);
        })
        .WithName("NotifyService")
        .WithOpenApi();
    }
}
