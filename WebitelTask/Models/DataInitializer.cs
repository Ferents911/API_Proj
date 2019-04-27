using API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebitelAPI.Models;

namespace WebitelTask.Models
{
    public class DataInitializer 
    {
        public static void Initialize(DataContext context)
        {
            
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var Products = new Product[]
            {
                new Product{Name = "Виделка", Price = 30 },
                new Product{Name = "Ложка", Price = 35 },
                new Product{Name = "Ніж", Price = 40 },
                new Product{Name = "Склянка", Price = 45 },
                new Product{Name = "Скатертина", Price = 75 },
                new Product{Name = "Рушник", Price = 50 },
            };
            foreach (Product s in Products)
            {
                context.Products.Add(s);
            }
            context.SaveChanges();

            var Orders = new Order[]
            {
                new Order {Number = 1, Amount = 200 },
                new Order {Number = 2, Amount = 150 },
                new Order {Number = 3, Amount = 240},
                new Order {Number = 4, Amount = 50 },
                new Order {Number = 5, Amount = 125},
                new Order {Number = 6, Amount = 100 },
            };
            foreach (Order o in Orders)
            {
                context.Orders.Add(o);
            }

            context.SaveChanges();

            var result = from OrderedProducts in context.OrderedProducts
                         join product in context.Products on OrderedProducts.ProductId equals product.Id
                         join order in context.Orders on OrderedProducts.OrderId equals order.Id
                         select new OrderProduct
                         {                          
                             OrderId = order.Id,
                             ProductId = product.Id
                         };

            context.SaveChanges();
             

            
            foreach(OrderProduct o in result.AsEnumerable())
            {             
                context.OrderedProducts.Add(o);
            }

           
            context.SaveChanges();

         
        }

    }
}
