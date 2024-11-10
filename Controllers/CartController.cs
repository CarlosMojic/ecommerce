using ecomerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecomerce.Controllers
{
    public class CartController : Controller
    {
        // Obtener el carrito de la sesión (si no existe, crear uno vacío)
        private List<Product> GetCart()
        {
            List<Product> cart = Session["Cart"] as List<Product>;
            if (cart == null)
            {
                cart = new List<Product>();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // Acción para agregar un producto al carrito
        public ActionResult AddToCart(int productId)
        {
            // Obtener el producto según el ID
            Product product = GetProductById(productId);

            if (product != null)
            {
                var cart = GetCart();
                cart.Add(product); // Añadir el producto al carrito
                Session["Cart"] = cart; // Actualizar la sesión con el carrito modificado
            }

            return RedirectToAction("Index", "Home"); // Redirigir a la página de inicio (o cualquier página que desees)
        }

        // Obtener un producto por su ID (simulación con una lista de productos estáticos)
        private Product GetProductById(int productId)
        {
            // Aquí puedes simular una lista de productos o recuperarlos de una base de datos
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Consola de PS4 Pro 1TB Negro", Price = 2000m},
                new Product { ProductId = 2, Name = "HP Laptop 15-EF1019LA", Price = 200m},
                new Product { ProductId = 3, Name = "Televisor 65 4K Ultra HD Smart TV", Price = 500m},
                new Product { ProductId = 4, Name = "Televisor 50 4K Ultra HD Smart Android", Price = 350m},
                new Product { ProductId = 5, Name = "Smartphone Xiaomi Redmi Note 10", Price = 200m},
                new Product { ProductId = 6, Name = "Smartphone Samsung Galaxy A52", Price = 300m},
                new Product { ProductId = 7, Name = "Auriculares Sony WH-1000XM4", Price = 20m},
                new Product { ProductId = 8, Name = "Microsoft Surface Pro 7", Price = 900m},
                
                //Seccion de ropa

                new Product { ProductId = 9, Name = "abrigo", Price = 20m},
                new Product { ProductId = 10, Name = "Blusa", Price = 10m},
                new Product { ProductId = 11, Name = "Camiseta", Price = 5m},
                new Product { ProductId = 12, Name = "Jean", Price = 8m},
                new Product { ProductId = 13, Name = "Pantalon de algodon", Price = 8m},
                new Product { ProductId = 14, Name = "Roopa deportiva", Price = 10m},
                new Product { ProductId = 15, Name = "Sudadera", Price = 20m},
                new Product { ProductId = 16, Name = "Vestido casual", Price = 10m},

                //Seccion de Herramientas

                new Product { ProductId = 17, Name = "abrigo", Price = 20m},
                new Product { ProductId = 18, Name = "abrigo", Price = 10m},
                new Product { ProductId = 19, Name = "abrigo", Price = 10m},
                new Product { ProductId = 20, Name = "abrigo", Price = 10m},
                new Product { ProductId = 21, Name = "abrigo", Price = 10m},
                new Product { ProductId = 22, Name = "abrigo", Price = 10m},
                new Product { ProductId = 23, Name = "abrigo", Price = 10m},
                new Product { ProductId = 24, Name = "abrigo", Price = 10m},

            };

            // Buscar el producto por su ID
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        // Acción para ver el carrito
        public ActionResult ViewCart()
        {
            var cart = GetCart();
            return View(cart); // Pasar la lista de productos del carrito a la vista
        }

        // Acción para eliminar un producto del carrito
        public ActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var product = cart.FirstOrDefault(p => p.ProductId == productId); // Buscar el producto por su ID

            if (product != null)
            {
                cart.Remove(product); // Eliminar el producto del carrito
                Session["Cart"] = cart; // Actualizar la sesión
            }

            return RedirectToAction("ViewCart"); // Redirigir al carrito para ver los cambios
        }
    }
}
