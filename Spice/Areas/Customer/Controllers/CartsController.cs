using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.Utility;
using Spice.Models.ViewModel;
using Stripe;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CartsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public OrderDetailCartViewModel OrderDetailCartsVM { get; set; }
        public IActionResult Index()
        {
            OrderDetailCartsVM = new OrderDetailCartViewModel()
            {
                OrderHeader = new Models.OrderHeader()
            };
            OrderDetailCartsVM.OrderHeader.OrderTotal = 0;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var ShoppingCart = db.ShoppingCarts.Where(m => m.ApplicationUserId == claims.Value);
            if (ShoppingCart != null)
            {
                OrderDetailCartsVM.ShoppingCartList = ShoppingCart.ToList();
            }
            foreach (var item in OrderDetailCartsVM.ShoppingCartList)
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId);
                OrderDetailCartsVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count;
                OrderDetailCartsVM.OrderHeader.OrderTotal = Math.Round(OrderDetailCartsVM.OrderHeader.OrderTotal, 2);
            }
            OrderDetailCartsVM.OrderHeader.OrderTotalOrginal = OrderDetailCartsVM.OrderHeader.OrderTotal;
            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                OrderDetailCartsVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);
                var CouponCodeFromDB = db.Coupons.Where(m => m.Name.ToLower() == HttpContext.Session.GetString(SD.ssCouponCode).ToLower()).FirstOrDefault();
                OrderDetailCartsVM.OrderHeader.OrderTotal = SD.DiscountPrice(CouponCodeFromDB, OrderDetailCartsVM.OrderHeader.OrderTotal);


            }
            return View(OrderDetailCartsVM);
        }
        public IActionResult ApplyCoupon()
        {
            if (OrderDetailCartsVM.OrderHeader.CouponCode == null)
            {
                OrderDetailCartsVM.OrderHeader.CouponCode = "";
            }
            HttpContext.Session.SetString(SD.ssCouponCode, OrderDetailCartsVM.OrderHeader.CouponCode);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveCoupon()
        {

            HttpContext.Session.SetString(SD.ssCouponCode, String.Empty);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Plus(int cartId)
        {
            var shoppingcart = await db.ShoppingCarts.FindAsync(cartId);
            shoppingcart.Count += 1;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Minus(int cartId)
        {
            var shoppingcart = await db.ShoppingCarts.FindAsync(cartId);
            if (shoppingcart.Count > 1)
            {
                shoppingcart.Count -= 1;
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int cartId)
        {
            var shoppingcart = await db.ShoppingCarts.FindAsync(cartId);

            db.ShoppingCarts.Remove(shoppingcart);
            await db.SaveChangesAsync();
            var count = db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingcart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(SD.ShoppingCartCount, count);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Summry()
        {
            OrderDetailCartsVM = new OrderDetailCartViewModel()
            {
                OrderHeader = new Models.OrderHeader()
            };
            OrderDetailCartsVM.OrderHeader.OrderTotal = 0;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var ShoppingCart = db.ShoppingCarts.Where(m => m.ApplicationUserId == claims.Value);
            var appUser = db.ApplicationUsers.Find(claims.Value);
            OrderDetailCartsVM.OrderHeader.PickUpName = appUser.Name;
            OrderDetailCartsVM.OrderHeader.PhoneNumber = appUser.PhoneNumber;
            OrderDetailCartsVM.OrderHeader.PickUpTime = DateTime.Now;
            if (ShoppingCart != null)
            {
                OrderDetailCartsVM.ShoppingCartList = ShoppingCart.ToList();
            }
            foreach (var item in OrderDetailCartsVM.ShoppingCartList)
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId);
                OrderDetailCartsVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count;
                OrderDetailCartsVM.OrderHeader.OrderTotal = Math.Round(OrderDetailCartsVM.OrderHeader.OrderTotal, 2);
            }
            OrderDetailCartsVM.OrderHeader.OrderTotalOrginal = OrderDetailCartsVM.OrderHeader.OrderTotal;
            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                OrderDetailCartsVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);
                var CouponCodeFromDB = db.Coupons.Where(m => m.Name.ToLower() == HttpContext.Session.GetString(SD.ssCouponCode).ToLower()).FirstOrDefault();
                OrderDetailCartsVM.OrderHeader.OrderTotal = SD.DiscountPrice(CouponCodeFromDB, OrderDetailCartsVM.OrderHeader.OrderTotal);

            }
            return View(OrderDetailCartsVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summry")]
        public async Task<IActionResult> SummryPost(string stripeToken)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            OrderDetailCartsVM.ShoppingCartList = await db.ShoppingCarts.Where(m => m.ApplicationUserId == claims.Value).ToListAsync();
            // var appUser = db.ApplicationUsers.Find(claims.Value);
            OrderDetailCartsVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            OrderDetailCartsVM.OrderHeader.OrderDate = DateTime.Now;
            OrderDetailCartsVM.OrderHeader.UserId = claims.Value;
            OrderDetailCartsVM.OrderHeader.Status = SD.PaymentStatusPending;
            OrderDetailCartsVM.OrderHeader.PickUpTime = Convert.ToDateTime(OrderDetailCartsVM.OrderHeader.PickUpDate.ToShortDateString() + " " +
                OrderDetailCartsVM.OrderHeader.PickUpTime.ToShortTimeString()
                );
            OrderDetailCartsVM.OrderHeader.OrderTotalOrginal = 0;
            db.OrderHeaders.Add(OrderDetailCartsVM.OrderHeader);
            await db.SaveChangesAsync();
            foreach (var item in OrderDetailCartsVM.ShoppingCartList)
            {

                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId);
                OrderDetail orderDetail = new OrderDetail()
                {
                    MenuItemId = item.MenuItemId,
                    OrderId = OrderDetailCartsVM.OrderHeader.Id,
                    Description=item.MenuItem.Description,
                    Name=item.MenuItem.Name,
                    Price=item.MenuItem.Price,
                    Count=item.Count
                };
                OrderDetailCartsVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count;
               db.orderDetails.Add(orderDetail);
            }
            
            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                OrderDetailCartsVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);
                var CouponCodeFromDB = db.Coupons.Where(m => m.Name.ToLower() == HttpContext.Session.GetString(SD.ssCouponCode).ToLower()).FirstOrDefault();
                OrderDetailCartsVM.OrderHeader.OrderTotal = SD.DiscountPrice(CouponCodeFromDB, OrderDetailCartsVM.OrderHeader.OrderTotal);

            }
            else
            {
                OrderDetailCartsVM.OrderHeader.OrderTotal = Math.Round(OrderDetailCartsVM.OrderHeader.OrderTotalOrginal,2);
            }
            OrderDetailCartsVM.OrderHeader.CouponCodeDiscount = OrderDetailCartsVM.OrderHeader.OrderTotalOrginal - OrderDetailCartsVM.OrderHeader.OrderTotal;
            db.ShoppingCarts.RemoveRange(OrderDetailCartsVM.ShoppingCartList);
            HttpContext.Session.SetInt32(SD.ShoppingCartCount, 0);
           await db.SaveChangesAsync();
            var options = new Stripe.ChargeCreateOptions
            {
                Amount=Convert.ToInt32(OrderDetailCartsVM.OrderHeader.OrderTotal*100),
                Currency="usd",
                Description="Order ID"+OrderDetailCartsVM.OrderHeader.Id,
                Source=stripeToken


            };
            var services = new ChargeService();
            Charge charge = services.Create(options);
            if (charge.BalanceTransactionId == null)
            {
                OrderDetailCartsVM.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }
            else
            {
                OrderDetailCartsVM.OrderHeader.TransactionId = charge.BalanceTransactionId;
            }
            if (charge.Status.ToLower() == "succeeded")
            {
                OrderDetailCartsVM.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
                OrderDetailCartsVM.OrderHeader.Status = SD.StatusSubmitted;
            }
            else
            {
                OrderDetailCartsVM.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }
            await db.SaveChangesAsync();
           // return RedirectToAction("Index","Home");
            return RedirectToAction("Confirm", "Orders", new {id= OrderDetailCartsVM.OrderHeader.Id});
        }
    }
}
