namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            CreateOrderViewModel viewOrder = new CreateOrderViewModel
            {
                Items = this.context
                    .Items
                    .ProjectTo<CreateOrderItemViewModel>
                    (this.mapper.ConfigurationProvider)
                    .ToList(),

                Employees = this.context
                    .Employees
                    .ProjectTo<CreateOrderEmployeeViewModel>
                    (this.mapper.ConfigurationProvider)
                    .ToList()
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            Order order = this.mapper.Map<Order>(model);
            OrderItem orderItem = this.mapper.Map<OrderItem>(model);

            orderItem.Order = order;

            this.context.Orders.Add(order);
            this.context.OrderItems.Add(orderItem);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            List<OrderAllViewModel> orders = this.context
                .Orders
                .ProjectTo<OrderAllViewModel>
                (this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}