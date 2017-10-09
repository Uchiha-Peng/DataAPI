using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductsController : Controller
    {
      private static readonly ToDoDBContext DBContext = new ToDoDBContext();

        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetProducts()
        {
            try
            {
                List<Product> list = DBContext.Product.ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 根据商品ID查询商品详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetProductByID(int ProID)
        {
            try
            {
                Product pro = DBContext.Product.Where(n=>n.ProId==ProID).FirstOrDefault();
                return Ok(pro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
