﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookstore.Domain.Carts;
using Bookstore.Domain.Customers;
using Microsoft.AspNetCore.Authorization;
using Bookstore.Customer.ViewModel;
using Bookstore.Customer;
using Bookstore.Data;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<ShoppingCartItem> _cartItemRepository;
        private readonly IGenericRepository<ShoppingCart> _cartRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGenericRepository<ShoppingCartItem> cartItemRepository,
                              IGenericRepository<Customer> customerRepository,
                              IGenericRepository<ShoppingCart> cartRepository,
                              ILogger<HomeController> logger)                              
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _customerRepository = customerRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //string ip;

            //if (User.Identity.IsAuthenticated)
            //{
            //    // get cart
            //    var cart = _cartRepository.Get(s => s.Customer.Id == User.GetUserId()).FirstOrDefault();

            //    // put cartid in cookie
            //    if (!HttpContext.Request.Cookies.ContainsKey("CartId"))
            //    {
            //        HttpContext.Response.Cookies.Append("CartId", cart.Cart_Id);
            //    }
            //    else
            //    {
            //        HttpContext.Response.Cookies.Delete("CartId");
            //        HttpContext.Response.Cookies.Append("CartId", cart.Cart_Id);
            //    }

            //    // put cart item in user cart
            //    var cartItem = _cartItemRepository.Get(c => c.Cart == cart && c.WantToBuy == true);

            //    foreach (var item in cartItem)
            //    {
            //        item.Cart = cart;
            //        _cartItemRepository.Update(item);
            //    }

            //    _cartItemRepository.Save();
            //}
            //else
            //{
            //    if (!HttpContext.Request.Cookies.ContainsKey("CartIp"))
            //    {
            //        ip = Guid.NewGuid().ToString();
            //        HttpContext.Response.Cookies.Append("CartIp", ip);
            //        var id = Guid.NewGuid().ToString();
            //        var cartInfo = new Cart { IP = ip, Cart_Id = id };
            //        _cartRepository.Add(cartInfo);
            //        _cartRepository.Save();
            //    }
            //    else
            //    {
            //        ip = HttpContext.Request.Cookies["CartIp"];
            //    }

            //    // put cart id in cookie
            //    var currentCart = _cartRepository.Get(s => s.IP == ip).FirstOrDefault();
            //    if (currentCart == null)
            //    {
            //        var id = Guid.NewGuid().ToString();
            //        currentCart = new Cart { IP = ip, Cart_Id = id };
            //        _cartRepository.Add(currentCart);
            //        _cartRepository.Save();
            //    }

            //    if (!HttpContext.Request.Cookies.ContainsKey("CartId"))
            //    {
            //        HttpContext.Response.Cookies.Append("CartId", currentCart.Cart_Id);
            //    }
            //    else
            //    {
            //        HttpContext.Response.Cookies.Delete("CartId");
            //        HttpContext.Response.Cookies.Append("CartId", currentCart.Cart_Id);
            //    }
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search()
        {
            return RedirectToAction("Index", "Search");
        }

        public IActionResult Cart()
        {
            return RedirectToAction("Index", "CartItems");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}