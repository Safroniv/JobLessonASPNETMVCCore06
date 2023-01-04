using Orders.DAL.Entities;

namespace JobLessonASPNETMVCCore06v02.Services
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(int buyerId, string address, string phone, IEnumerable<(int productId, int quantity)> products);
    }
}
