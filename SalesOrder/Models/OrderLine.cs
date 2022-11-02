using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesOrder.Models
{
    public class OrderLine
    {
        public int LineNumber { get; set; }
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Enter Product Code")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Enter Product Type")]
        public string ProductType { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Enter Cost Price")]
        public double CostPrice { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Enter Sale Price")]
        public double SalePrice { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Enter Quantity")]
        public int Quantity { get; set; }
    }
    public enum ProductTypes
    {
        Apparel, Parts, Equipment, Motor
    }
}