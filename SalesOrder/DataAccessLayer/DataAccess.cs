using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using SalesOrder.Models;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace SalesOrder.DataAccessLayer
{
    public class DataAccess
    {
        private string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        private SqlConnection con = null;

        public bool InsertOrder(OrderHeader order)
        {


        bool result;
            try
            {
                    
                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_InsertOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                this.con.Close();
                con.Open(); 
                cmd.Parameters.AddWithValue("@orderNumber", order.OrderNumber);
                cmd.Parameters.AddWithValue("@custName", order.CustomerName);
                cmd.Parameters.AddWithValue("@orderType", order.OrderType);
                cmd.Parameters.AddWithValue("@orderStatus", order.OrderStatus);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                int count = cmd.ExecuteNonQuery();
            if (count < 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
                return result;
            }
            catch(Exception e)
            {
                return result = false;
            }
            finally
            {
                this.con.Close();
            }
        }
        public bool updateOrder(OrderHeader order)
        {
            bool result;
            try
            {

                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_InsertOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                this.con.Close();
                con.Open();
                //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                cmd.Parameters.AddWithValue("@order_num", order.OrderNumber);
                cmd.Parameters.AddWithValue("@cust_name", order.CustomerName);
                cmd.Parameters.AddWithValue("@order_type", order.OrderType);
                cmd.Parameters.AddWithValue("@order_status", order.OrderStatus);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception e)
            {
                return result = false;
            }
            finally
            {
                this.con.Close();
            }
        }
        //public int DeleteData(String ID)
        //{
        //    SqlConnection con = null;
        //    int result;
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CustomerID", ID);
        //        cmd.Parameters.AddWithValue("@Name", null);
        //        cmd.Parameters.AddWithValue("@Address", null);
        //        cmd.Parameters.AddWithValue("@Mobileno", null);
        //        cmd.Parameters.AddWithValue("@Birthdate", null);
        //        cmd.Parameters.AddWithValue("@EmailID", null);
        //        cmd.Parameters.AddWithValue("@Query", 3);
        //        con.Open();
        //        result = cmd.ExecuteNonQuery();
        //        return result;
        //    }
        //    catch
        //    {
        //        return result = 0;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public List<Customer> Selectalldata()
        //{
        //    SqlConnection con = null;
        //    DataSet ds = null;
        //    List<Customer> custlist = null;
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CustomerID", null);
        //        cmd.Parameters.AddWithValue("@Name", null);
        //        cmd.Parameters.AddWithValue("@Address", null);
        //        cmd.Parameters.AddWithValue("@Mobileno", null);
        //        cmd.Parameters.AddWithValue("@Birthdate", null);
        //        cmd.Parameters.AddWithValue("@EmailID", null);
        //        cmd.Parameters.AddWithValue("@Query", 4);
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        custlist = new List<Customer>();
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            Customer cobj = new Customer();
        //            cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
        //            cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
        //            cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
        //            cobj.Mobileno = ds.Tables[0].Rows[i]["Mobileno"].ToString();
        //            cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
        //            cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());

        //            custlist.Add(cobj);
        //        }
        //        return custlist;
        //    }
        //    catch
        //    {
        //        return custlist;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //public Customer SelectDatabyID(string CustomerID)
        //{
        //    SqlConnection con = null;
        //    DataSet ds = null;
        //    Customer cobj = null;
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
        //        cmd.Parameters.AddWithValue("@Name", null);
        //        cmd.Parameters.AddWithValue("@Address", null);
        //        cmd.Parameters.AddWithValue("@Mobileno", null);
        //        cmd.Parameters.AddWithValue("@Birthdate", null);
        //        cmd.Parameters.AddWithValue("@EmailID", null);
        //        cmd.Parameters.AddWithValue("@Query", 5);
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            cobj = new Customer();
        //            cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
        //            cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
        //            cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
        //            cobj.Mobileno = ds.Tables[0].Rows[i]["Mobileno"].ToString();
        //            cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
        //            cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());

        //        }
        //        return cobj;
        //    }
        //    catch
        //    {
        //        return cobj;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public List<OrderHeader> getAllOrders()
        {
            List<OrderHeader> result;
            DataSet ds;
            try
            {

                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_getAllOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                this.con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                result = new List<OrderHeader>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    OrderHeader type = new OrderHeader();
                    type.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    type.OrderNumber = ds.Tables[0].Rows[i]["orderNumber"].ToString();
                    type.OrderType = ds.Tables[0].Rows[i]["orderType"].ToString();
                    type.OrderStatus = ds.Tables[0].Rows[i]["OrderStatus"].ToString();
                    type.CustomerName = ds.Tables[0].Rows[i]["customerName"].ToString();
                    type.OrderDate =Convert.ToDateTime( ds.Tables[0].Rows[i]["createDate"].ToString());

                    result.Add(type);
                }
                ds.Clear();
                return result;
            }
            catch (Exception e)
            {
                return result = null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<OrderLine> getOrderLineByOrderNumber(string id)
        {
            List<OrderLine> result;
            DataSet ds;
            try
            {

                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_getOrderLineByOrderNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                this.con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                result = new List<OrderLine>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.LineNumber = Convert.ToInt32(ds.Tables[0].Rows[i]["lineNumber"].ToString());
                    orderLine.OrderID = Convert.ToInt32(ds.Tables[0].Rows[i]["orderId"].ToString());
                    orderLine.ProductCode = ds.Tables[0].Rows[i]["productCode"].ToString();
                    orderLine.ProductType = ds.Tables[0].Rows[i]["productType"].ToString();
                    orderLine.CostPrice = Convert.ToDouble( ds.Tables[0].Rows[i]["productCostPrice"].ToString());
                    orderLine.SalePrice = Convert.ToDouble(ds.Tables[0].Rows[i]["productsalePrice"].ToString());
                    orderLine.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"].ToString());
                    

                    result.Add(orderLine);
                }
                ds.Clear();
                return result;
            }
            catch (Exception e)
            {
                return result = null;
            }
            finally
            {
                con.Close();
            }
        }

        public OrderLine getOrderLineById(string id)
        {
            OrderLine orderLine;
            DataSet ds;
            try
            {

                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_getOrderLineById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lineNumber", Convert.ToInt32(id));
                this.con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                orderLine = new OrderLine();
                orderLine.LineNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["lineNumber"].ToString());
                orderLine.OrderID = Convert.ToInt32(ds.Tables[0].Rows[0]["orderId"].ToString());
                orderLine.ProductCode = ds.Tables[0].Rows[0]["productCode"].ToString();
                orderLine.ProductType = ds.Tables[0].Rows[0]["productType"].ToString();
                orderLine.CostPrice = Convert.ToDouble(ds.Tables[0].Rows[0]["productCostPrice"].ToString());
                orderLine.SalePrice = Convert.ToDouble(ds.Tables[0].Rows[0]["productsalePrice"].ToString());
                orderLine.Quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["quantity"].ToString());

                ds.Clear();
                return orderLine;
            }
            catch (Exception e)
            {
                return orderLine = null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool insertOrderLine(OrderLine orderLine)
        {
            bool result;
            try
            {

                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_InsertOrderLine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                this.con.Close();
                con.Open();
                //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                cmd.Parameters.AddWithValue("@OrderID", orderLine.OrderID);
                cmd.Parameters.AddWithValue("@ProductCode", orderLine.ProductCode);
                cmd.Parameters.AddWithValue("@ProductType", orderLine.ProductType);
                cmd.Parameters.AddWithValue("@productCostPrice", orderLine.CostPrice);
                cmd.Parameters.AddWithValue("@productSalePrice", orderLine.SalePrice);
                cmd.Parameters.AddWithValue("@quantity", orderLine.Quantity);

                int count = cmd.ExecuteNonQuery();
                if (count < 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception e)
            {
                return result = false;
            }
            finally
            {
                this.con.Close();
            }
        }

        public bool updateOrderLine(OrderLine orderLine)
        {
            bool result;
            try
            {

                con = new SqlConnection(this.strcon);
                SqlCommand cmd = new SqlCommand("Usp_updateOrderLine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                this.con.Close();
                con.Open();
                cmd.Parameters.AddWithValue("@lineNumber", orderLine.LineNumber);
                cmd.Parameters.AddWithValue("@ProductCode", orderLine.ProductCode);
                cmd.Parameters.AddWithValue("@ProductType", orderLine.ProductType);
                cmd.Parameters.AddWithValue("@productCostPrice", orderLine.CostPrice);
                cmd.Parameters.AddWithValue("@productSalePrice", orderLine.SalePrice);
                cmd.Parameters.AddWithValue("@quantity", orderLine.Quantity);

                int count = cmd.ExecuteNonQuery();
                if (count < 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception e)
            {
                return result = false;
            }
            finally
            {
                this.con.Close();
            }
        }
    }
}
