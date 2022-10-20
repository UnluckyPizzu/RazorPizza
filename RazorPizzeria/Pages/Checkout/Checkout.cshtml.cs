using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet =true)]
    public class CheckoutModel : PageModel
    {
        
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;
        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context; 
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(PizzaName))
            {
                PizzaName = "Custom";
            }
            if(string.IsNullOrEmpty(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel();
            pizzaOrderModel.PizzaName = PizzaName;
            pizzaOrderModel.BasePrice = PizzaPrice;
            _context.PizzaOrders.Add(pizzaOrderModel);
            _context.SaveChanges();
        }
    }
}
