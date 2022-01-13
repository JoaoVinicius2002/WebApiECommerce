using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using WebApiECommerce.Context;
using WebApiECommerce.Models;
using WebApiECommerce.Models.ViewModels;

namespace WebApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        [Route("GetOrders")]
        public void AddDatabaseContent()
        {
            //var product1 = new Product("Bola de basquete", "Bola utilizada para praticar basquetebol. Garantia de 2 meses.", (decimal)198.99);
            //var product2 = new Product("Bola de futebol", "Bola utilizada para praticar futebol. Garantia de 1 mês.", (decimal)99.99);
            //var product3 = new Product("Tênis Jordan 1", "Primeiro tênis criado pelo Michael Jordan.", (decimal)970.00);
            //var product4 = new Product("Apito", "Apito para arbitrar jogos de diversos esportes. Em promoção, por tempo limitado", (decimal)26.99);
            //var product5 = new Product("Carrinho", "Carrinho. Em promoção, por tempo limitado", (decimal)39.99);
            //var product6 = new Product("Xadrez", "Xadrez. Em promoção, por tempo limitado", (decimal)211.99);
            //var product7 = new Product("Transformers", "Em promoção, por tempo limitado", (decimal)93.99);
            //var product8 = new Product("Hot Wheels", "Em promoção, por tempo limitado", (decimal)62.99);
            //_applicationDbContext.Products.Add(product1);
            //_applicationDbContext.Products.Add(product2);
            //_applicationDbContext.Products.Add(product3);
            //_applicationDbContext.Products.Add(product4);
            //_applicationDbContext.Products.Add(product5);
            //_applicationDbContext.Products.Add(product6);
            //_applicationDbContext.Products.Add(product7);
            //_applicationDbContext.Products.Add(product8);
            //_applicationDbContext.SaveChanges();

            //List<Product> products = new List<Product>();
            //products.Add(product1);
            //products.Add(product2);
            //products.Add(product3);
            //products.Add(product4);

            //var team1 = new Team("Time de entegas Zona Sul", "Time responsável pelas entregas da zona sul de São Paulo", "DYJ-2312");
            //var team2 = new Team("Time de entegas Zona Norte", "Time responsável pelas entregas da zona norte de São Paulo", "ZUE-5623");
            //var team3 = new Team("Time de entegas externas", "Time responsável pelas entregas fora de São Paulo", "SDE-4351");
            //_applicationDbContext.Teams.Add(team1);
            //_applicationDbContext.Teams.Add(team2);
            //_applicationDbContext.Teams.Add(team3);
            //_applicationDbContext.SaveChanges();


            //var order1 = new Order(40, DateTime.UtcNow, DateTime.MinValue, "Rua curuça, n 17. Itapecerica da Serra");
            //var order2 = new Order(41, DateTime.UtcNow, DateTime.MinValue, "Rua Mocajuba, n 1329. Jardim do Éden");
            //var order3 = new Order(41, DateTime.UtcNow, DateTime.MinValue, "Rua Alves Dias, n 19. Jardim do Éden");
            //var order4 = new Order(42, DateTime.UtcNow, DateTime.MinValue, "Rua José Marques, n 19. Horizonte Azul");
            //var order5 = new Order(42, DateTime.UtcNow, DateTime.MinValue, "Rua Presidente Costa e Silva, n 19. Santa Julia");
            //var order6 = new Order(42, DateTime.UtcNow, DateTime.MinValue, "Avenida Plínio Dias, n 1292. Calú");

            //_applicationDbContext.Orders.Add(order1);
            //_applicationDbContext.Orders.Add(order2);
            //_applicationDbContext.Orders.Add(order3);
            //_applicationDbContext.Orders.Add(order4);
            //_applicationDbContext.Orders.Add(order5);
            //_applicationDbContext.Orders.Add(order6);
            //_applicationDbContext.SaveChanges();

            //var orderProduct1 = new OrderProduct(41, 53);
            //var orderProduct2 = new OrderProduct(42, 54);
            //var orderProduct3 = new OrderProduct(43, 53);
            //var orderProduct4 = new OrderProduct(43, 54);
            //var orderProduct5 = new OrderProduct(44, 55);
            //var orderProduct6 = new OrderProduct(45, 56);
            //var orderProduct7 = new OrderProduct(45, 57);
            //var orderProduct8 = new OrderProduct(46, 58);
            //var orderProduct9 = new OrderProduct(46, 59);

            //_applicationDbContext.OrderProducts.Add(orderProduct1);
            //_applicationDbContext.OrderProducts.Add(orderProduct2);
            //_applicationDbContext.OrderProducts.Add(orderProduct3);
            //_applicationDbContext.OrderProducts.Add(orderProduct4);
            //_applicationDbContext.OrderProducts.Add(orderProduct5);
            //_applicationDbContext.OrderProducts.Add(orderProduct6);
            //_applicationDbContext.OrderProducts.Add(orderProduct7);
            //_applicationDbContext.OrderProducts.Add(orderProduct8);
            //_applicationDbContext.OrderProducts.Add(orderProduct9);
            //_applicationDbContext.SaveChanges();


        }
        [HttpGet]
        [Route("GetAllOrders")]
        public IEnumerable<OrderProductDTO> GetAllOrders()
        {
            var orderProducts = _applicationDbContext.Orders
                .Include(e => e.OrderProducts)
                .Include(e => e.Team)
                .Select(e => new OrderProductDTO {
                    Products = e.OrderProducts.Where(f => f.OrderId == e.Id).Select(f => f.Product).ToList(),
                    TotalPrice = e.OrderProducts.Where(f => f.OrderId == e.Id).Sum(f => f.Product.Price),
                    OrderId = e.Id,
                    TeamId = e.TeamId,
                    Team = e.Team,
                    OrderAddress = e.Address,
                    OrderWhenCreated = e.WhenCreated,
                    OrderWhenDelivered = e.WhenDelivered
                })
                .ToList();

            return orderProducts;

        }
    }
}
