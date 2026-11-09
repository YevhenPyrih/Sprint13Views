using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SprViews.Controllers
{
    public class TasksController : Controller
    {
        List<string> supermarkets = new List<string>
            {
                "Silpo",
                "ATB",
                "Metro",
                "Aushan",
                "Novus"
            };

        Dictionary<string, int> products = new Dictionary<string, int>
            {
                { "Milk", 2 },
                { "Bread", 1 },
                { "Eggs", 12 },
                { "Cheese", 1 },
                { "Apples", 6 }
            };

        public IActionResult Supermarkets()
        {
            
            ViewBag.Supermarkets = supermarkets;
            return View("Supermarkets");
        }

        public IActionResult ShoppingList()
        { 
            return View("ShoppingList", products);
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            ViewBag.Products = new MultiSelectList(products.Keys.ToList());
            ViewBag.Supermarkets = new SelectList(supermarkets);
            return View("ShoppingCart");
        }

        [HttpPost]
        public IActionResult ShoppingCart(string Fullname, string Address)
        {
            string resultMessage = $"Your products will be shipped to: {Address}. Bon appetite, {Fullname}!";
            return Content(resultMessage);
        }

        public IActionResult Greetings()
        {
            ViewBag.Message = "Hello, welcome to our store!";
            ViewBag.Greeting = "We are glad to have you here.";
            return View("Greetings");
        }

        public IActionResult ProductInfo()
        {
            return View("ProductInfo");
        }

        public IActionResult SprintTasks()
        {
            return View("SprintTasks");
        }
        
        public IActionResult TimeToBuy()
        {
            return PartialView("TimeToBuy");
        }
    }
}
