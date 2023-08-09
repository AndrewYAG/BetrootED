using EntityFrameworkHW.Models;

namespace EntityFrameworkHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopDbContext())
            {
                /*var productId = Guid.NewGuid();
                context.Products.Add(new Product()
                {
                    Id = productId,
                    Name = "OPPo A5",
                    Description = "Not reade yet",
                    Price = 225.34M,
                    AvailableForPurchase = false
                });
                context.SaveChanges();*/

                var empoyeeId = Guid.NewGuid();
                context.Employees.Add(new Employee()
                {
                    Id = empoyeeId,
                    FirstName = "Andre",
                    LastName = "Guso",
                    Phone = "+64136142353"
                });

                var orderId = Guid.NewGuid();
                context.Orders.Add(new Order()
                {
                    Id = orderId,
                    Address = "Ternopil, Slavuta st.",
                    UserId = new Guid("3779EDC2-A7B3-4744-8124-21998F878535"),
                    OrderDetails = "really fast delivery",
                    EmployeeId = empoyeeId,
                    ProductId = new Guid("DBA0CED5-4940-40C9-96A7-017E77883798")
                });

                context.SaveChanges();








                /*                var userId = Guid.NewGuid();
                                context.Users.Add(new User()
                                {
                                    Id = userId,
                                    FirstName = "Sergo",
                                    LastName = "Quieez",
                                    Phone = "+3842532128421"
                                });

                                var users = context.Users.Include("Orders").Where(x => x.Orders.
                                Any(x => x.OrderDetails == "Give me some clothes and motorcycle")).ToList();*/


                //var allOrders = context.Orders.Where(x => x.OrderDetails == "Give me some clothes and motorcycle").ToList();

                //var selectAll = context.Database.SqlQuery<Order>("Select * From Orders").ToList();


                /*var userId = Guid.NewGuid();
                context.Users.Add(new User()
                {
                    Id = userId,
                    FirstName = "Andrew",
                    LastName = "Sokolov",
                    Phone = "+380952132141"
                });
                context.Orders.Add(new Order()
                {
                    Id = Guid.NewGuid(),
                    Address = "Kyiv, Khreschatic st.",
                    OrderDetails = "Give me some clothes and motorcycle",
                    UserId = userId
                });
                context.Orders.Add(new Order()
                {
                    Id = Guid.NewGuid(),
                    Address = "Kyiv, Lesi Ukrainki blvd.",
                    OrderDetails = "Give me some ice cream",
                    UserId = userId
                });*/
            }

            //Console.ReadLine();
        }
    }
}