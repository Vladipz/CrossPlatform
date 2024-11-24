using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Endpoints
{
    public static class OrdersApi
    {
        public static void MapOrdersEndpoints(this IEndpointRouteBuilder app)
        {
            _ = app.MapGet("/api/search/byorderdate", async (
                DateTime? startDate,
                DateTime? endDate,
                SpecialistBookshopDbContext context) =>
            {
                if (startDate == null || endDate == null)
                {
                    return Results.Ok(new List<Order>());
                }

                var orders = await context.Orders
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .Include(o => o.Customer)
                    .ToListAsync();

                return Results.Ok(orders);
            })
            .WithName("GetOrdersByDateRange");
        }
    }
}
