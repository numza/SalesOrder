using SalesOrder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesOrder.DataAccessLayer;


namespace SalesOrder.Controllers
{

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            List<OrderHeader> orders = new List<OrderHeader>();
            DataAccess access = new DataAccess();
            orders = access.getAllOrders();

            return View(orders);
        }
        public JsonResult getOrderLineByOrderNumber(string id)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            DataAccess access = new DataAccess();
            orderLines = access.getOrderLineByOrderNumber(id);

            return Json(orderLines, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(OrderHeader order)
        {
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccess access = new DataAccess();
                bool result = access.InsertOrder(order);
                if(result)
                {
                    ViewBag.Message = "Order details was add Successfull!!";
                    ModelState.Clear(); //clearing model          
                    return View();
                }
                ViewBag.Message = "Something went wron. Tyr again!!";
                    

                return View();

            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}