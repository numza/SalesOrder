using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesOrder.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Order Number")]
        public string OrderNumber { get; set; }
        //string customerid { get; set; }
        [Required(ErrorMessage = "Enter Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Select Order Status")]
        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Select Order Type")]
        public string OrderType { get; set; }
    }
    public enum Types
    {
        Normal, Staff, Mechanical, Perishable
    }

    public enum Status
    {
        New, Processing, Complete
    }
}