using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.DAL;

namespace JobLessonASPNETMVCCore06v02
{
    internal class Sample02
    {
        static void Main(string[] args)
        {
            var serviceBuilder = new ServiceCollection();

            #region Configure EF DBContecst Service
            serviceBuilder.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlServer("data source = SAFRONIV-HONOR\\SQLEXPRESS; " +
                "initial catalog = OrdersDatabase2; User Id = OrdersUser; Password =12345;" +
                "MultipleActiveResultSets=True;App=EntityFramework; TrustServerCertificate=True");
            });
            #endregion

            //serviceBuilder.AddSingleton<Iservice, ServiceImplementation>();

            var serviceProvider = serviceBuilder.BuildServiceProvider();

            var context = serviceProvider.GetRequiredService<OrdersDbContext>();

            foreach (var buyer in context.Buyers)
            {
                Console.WriteLine($"{buyer.LastName} {buyer.Name} {buyer.Patronymic} {buyer.Birthday.ToShortDateString()}");
            }
            Console.ReadKey(true);

        }
    }
}
