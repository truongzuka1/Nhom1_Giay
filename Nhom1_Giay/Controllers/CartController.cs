﻿using Microsoft.AspNetCore.Mvc;
using Nhom1_Giay.Models;

namespace Nhom1_Giay.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context) => _context = context;

        public IActionResult Index()
        {
            var cart = _context.CartItems.ToList();
            return View(cart);
        }

        public IActionResult AddToCart(int shoeId)
        {
            var cartItem = new CartItem { ShoeId = shoeId, Quantity = 1 };
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
