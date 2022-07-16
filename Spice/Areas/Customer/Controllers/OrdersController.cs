using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.Utility;
using Spice.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrdersController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Confirm(int id)
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            OrderDetailViewModel OrderDetailVM = new OrderDetailViewModel()
            {
                OrderHeader = await db.OrderHeaders.Include(m=>m.ApplicationUser).FirstOrDefaultAsync(m => m.UserId == claims.Value && m.Id == id),
                OrderDetails=await db.orderDetails.Where(m=>m.OrderId==id).ToListAsync()

            };
            return View(OrderDetailVM);
        }
        private int pageSize = 2;
        [Authorize]
        public async Task<IActionResult> OrderHistory(int pageNumber=1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // List<OrderDetailViewModel> OrderDetailVMList = new List<OrderDetailViewModel>();
            OrderListViewModel OrderListVM = new OrderListViewModel()
            {
                Orders=new List<OrderDetailViewModel>(),

            };
            List<OrderHeader>OrderHeaderList=await db.OrderHeaders.Include(m=>m.ApplicationUser).Where(m=>m.UserId==claims.Value).ToListAsync();
            foreach (var orderHeader in OrderHeaderList)
            {
                OrderDetailViewModel OrderDetailsVM = new OrderDetailViewModel()
                {
                    OrderHeader=orderHeader,
                    OrderDetails=await db.orderDetails.Where(m=>m.OrderId==orderHeader.Id).ToListAsync()
                };
                OrderListVM.Orders.Add(OrderDetailsVM);
            }
            var count=OrderListVM.Orders.Count;
            OrderListVM.Orders = OrderListVM.Orders.OrderByDescending(o => o.OrderHeader.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            OrderListVM.pagingInfo = new pagingInfo()
            {
                CurrentPage=pageNumber,
                RecordsPerPage=pageSize,   
                TotalRecords=count,
                urlParam= "/Customer/Orders/OrderHistory?pageNumber=:"


            };
            return View(OrderListVM);

        }


        public async Task<IActionResult>GetOrderDetails(int id)
        {
            OrderDetailViewModel OrderDetailVM = new OrderDetailViewModel()
            {
                OrderHeader = await db.OrderHeaders.Include(m => m.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id),
                OrderDetails=await db.orderDetails.Where(m=>m.Id==id).ToListAsync()
            };
            return PartialView("_IndividualOrderDetails", OrderDetailVM);   
        }


        public async Task<IActionResult> GetOrderStatus(int  id)
        {

          OrderHeader orderHeader=await db.OrderHeaders.FindAsync(id);
            return PartialView("_OrderStatus", orderHeader.Status);
        }


        [Authorize(Roles =SD.ManagerUser +","+SD.KitchenUser)]
        public async Task<IActionResult> ManageOrder()
        {
          
             List<OrderDetailViewModel> OrderDetailVMList = new List<OrderDetailViewModel>();
           
            List<OrderHeader> OrderHeaderList = await db.OrderHeaders.Where(o=>o.Status==SD.StatusInProccess || o.Status==SD.StatusSubmitted).ToListAsync();
            foreach (var orderHeader in OrderHeaderList)
            {
                OrderDetailViewModel OrderDetailsVM = new OrderDetailViewModel()
                {
                    OrderHeader = orderHeader,
                    OrderDetails = await db.orderDetails.Where(m => m.OrderId == orderHeader.Id).ToListAsync()
                };
                OrderDetailVMList.Add(OrderDetailsVM);
            }
           
            return View(OrderDetailVMList.OrderBy(o=>o.OrderHeader.PickUpTime).ToList());

        }


        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]
        public async Task<IActionResult> OrderPrepare(int orderId)
        {
            OrderHeader orderHeader=await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusInProccess;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(ManageOrder));
        }



        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]
        public async Task<IActionResult> OrderReady(int orderId)
        {
            OrderHeader orderHeader = await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusReady;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(ManageOrder));
        }



        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]


        public async Task<IActionResult> OrderCancel(int orderId)
        {
            OrderHeader orderHeader = await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusCancelled;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(ManageOrder));
        }



        [Authorize(Roles =SD.ManagerUser + ","+SD.FrontDeskUser)]
        public async Task<IActionResult> OrderPickUp(int pageNumber = 1,string searchName=null,string searchPhone=null,string searchEmail=null)
        {
            
            
            OrderListViewModel OrderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailViewModel>(),

            };
            StringBuilder param = new StringBuilder();
            param.Append("/Customer/Orders/OrderPickUp?pageNumber=:");
            param.Append("&searchName=");
            if(searchName != null)
            {
                param.Append(searchName);   
            }
            else
            {
                searchName = "";
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }
            else
            {
                searchPhone = "";
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            else
            {
                searchEmail= "";
            }
            List<OrderHeader> OrderHeaderList = await db.OrderHeaders.Include(m => m.ApplicationUser).OrderByDescending(o=>o.OrderDate)
                .Where(m => m.Status==SD.StatusReady && m.PickUpName.Contains(searchName) && m.PhoneNumber.Contains(searchPhone) && m.ApplicationUser.Email.Contains(searchEmail))
                .ToListAsync();
            foreach (var orderHeader in OrderHeaderList)
            {
                OrderDetailViewModel OrderDetailsVM = new OrderDetailViewModel()
                {
                    OrderHeader = orderHeader,
                    OrderDetails = await db.orderDetails.Where(m => m.OrderId == orderHeader.Id).ToListAsync()
                };
                OrderListVM.Orders.Add(OrderDetailsVM);
            }
            var count = OrderListVM.Orders.Count;
            OrderListVM.Orders = OrderListVM.Orders.OrderByDescending(o => o.OrderHeader.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            OrderListVM.pagingInfo = new pagingInfo()
            {
                CurrentPage = pageNumber,
                RecordsPerPage = pageSize,
                TotalRecords = count,
                urlParam =param.ToString()


            };
            return View(OrderListVM);

        }
        [Authorize(Roles = SD.ManagerUser + "," + SD.FrontDeskUser)]

        [HttpPost]
        public async Task<IActionResult> OrderPickUp(int orderId)
        {
            OrderHeader orderHeader = await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusComleted;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(OrderPickUp));
        }
    }
}
