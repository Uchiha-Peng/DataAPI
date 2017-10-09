using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ShopCartsController : Controller
    {

        private static readonly ToDoDBContext db = new ToDoDBContext();


        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [Route("api/[controller]/[action]")]
        public ActionResult AddToShopCart(int uid, int proid, int num)
        {
            try
            {
                User u = db.User.ToList().Where(n => (n.Uid == uid)).SingleOrDefault();
                if (u != null)
                {
                    //购物车中是否存在该物品
                    Shopcart cart = db.Shopcart.Where(n => n.ProId == proid && n.Uid == u.Uid).SingleOrDefault();
                    //存在就添加数量
                    if (cart != null)
                    {
                        cart.Num += num;
                        db.SaveChanges();
                    }
                    //否则就新增
                    else
                    {
                        cart = new Shopcart();
                        cart.Uid = u.Uid;
                        cart.Num = num;
                        cart.ProId = proid;
                        db.Shopcart.Add(cart);
                        db.SaveChanges();
                    }
                    return Ok("添加成功");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 查询当前用户购物车信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[Action]")]

        public ActionResult SearchShopCart(int uid)
        {
            try
            {
                User u = db.User.ToList().Where(n => (n.Uid == uid)).SingleOrDefault();
                //判断用户是否存在
                //存在就查询
                if (u != null)
                {
                    List<Shopcart> list = db.Shopcart.Where(n => n.Uid == uid).ToList();
                    return Ok(list);
                }
                //不存在就返回NotFound
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
