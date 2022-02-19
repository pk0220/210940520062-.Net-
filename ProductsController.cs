using DotNetLabExam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetLabExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> list = new List<Product>();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True;Connect Timeout=30;";
            sc.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sc;
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Products";
            SqlDataReader sdr = sqlcmd.ExecuteReader();
            while (sdr.Read()) 
            {
                Product p = new Product();
                p.ProductId = (int)sdr["ProductId"];
                p.ProductName = sdr["ProductName"].ToString();
                p.Rate = (decimal)sdr["Rate"];
                p.Description = sdr["Description"].ToString();
                p.CategoryName=sdr["CategoryName"].ToString();
                list.Add(p);
            }
            sc.Close();
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True;Connect Timeout=30;";
                sc.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sc;
                sqlcmd.CommandType = System.Data.CommandType.Text;
                sqlcmd.CommandText = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@ProductId";
                sqlcmd.Parameters.AddWithValue("@ProductId", id);
                sqlcmd.Parameters.AddWithValue("@ProductName",p.ProductName);
                sqlcmd.Parameters.AddWithValue("@Rate",p.Rate);
                sqlcmd.Parameters.AddWithValue("@Description",p.Rate);
                sqlcmd.Parameters.AddWithValue("@CategoryName",p.CategoryName);
                sqlcmd.ExecuteNonQuery();
                sc.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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
