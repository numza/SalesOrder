using SalesOrder.DataAccessLayer;
using SalesOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOrder.Controllers
{
    public class OrderLineController : Controller
    {
        
        // GET: OrderLine/Add
        public ActionResult Add(string id)
        {
            OrderLine orderLine = new OrderLine();
            orderLine.OrderID = Convert.ToInt32(id);
            
            return View(orderLine);
        }

        // POST: OrderLine/Add
        [HttpPost]
        public ActionResult Add(OrderLine orderLine)
        {
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccess access = new DataAccess();
                bool result = access.insertOrderLine(orderLine);
                if (result)
                {
                    ViewBag.Message = "OrderLine details was add Successfull!!";
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

        // GET: OrderLine/Edit/5
        public JsonResult getOrderLineByOrderNumber(string id)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            DataAccess access = new DataAccess();
            orderLines = access.getOrderLineByOrderNumber(id);

            return Json(orderLines, JsonRequestBehavior.AllowGet);
        }

        // POST: OrderLine/Edit/5
        
        public JsonResult getOrderLineById(string id)
        {
            OrderLine orderLines = new OrderLine();
            DataAccess access = new DataAccess();
            orderLines = access.getOrderLineById(id);

            return Json(orderLines, JsonRequestBehavior.AllowGet);
        }

        // GET: OrderLine/edit
        
        public JsonResult Edit(FormCollection collection)
        {
            try
            {
                OrderLine orderLine = new OrderLine();
                orderLine.OrderID = Convert.ToInt32(collection.Get("OrderID").ToString());
                orderLine.ProductCode = collection.Get("ProductCode").ToString();
                orderLine.ProductType = collection.Get("ProductType").ToString();
                orderLine.CostPrice = Convert.ToDouble( collection.Get("CostPrice"));
                orderLine.SalePrice = Convert.ToDouble(collection.Get("SalePrice"));
                orderLine.Quantity = Convert.ToInt32(collection.Get("Quantity"));
                orderLine.LineNumber = Convert.ToInt32(collection.Get("LineNumber"));
                DataAccess access = new DataAccess();
                bool result = access.updateOrderLine(orderLine);
                if (result)
                {
                    ViewBag.Message = "OrderLine details was add Successfull!!";
                    List<OrderLine> orderLines = new List<OrderLine>();
                    DataAccess dataAccess = new DataAccess();
                    orderLines = access.getOrderLineByOrderNumber(orderLine.OrderID.ToString());

                    return Json(orderLines, JsonRequestBehavior.AllowGet);
                }
                return Json("Something is wrong. Please Make sure All Fields Are Filled", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Something is wrong. Please Make sure All Fields Are Filled", JsonRequestBehavior.AllowGet);
            }

        }

        // POST: OrderLine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
