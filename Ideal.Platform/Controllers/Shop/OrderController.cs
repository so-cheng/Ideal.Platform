using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Ideal.Shop.Model;
using Ideal.Shop.Model.Query;
using Ideal.Shop.Service;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Ideal.Platform.Controllers.Shop
{
    public class OrderController : Controller
    {
        public JsonResult InsertOrder(Shop_OrderModel model)
        {
            Shop_OrderService shop_OrderService = new Shop_OrderService();
            ReturnSummary returnSummary = shop_OrderService.InsertOrder(model);
            return Json(returnSummary);
        }
        public JsonResult UpdateOrder(Shop_OrderModel model)
        {
            Shop_OrderService shop_OrderService = new Shop_OrderService();
            ReturnSummary returnSummary = shop_OrderService.UpdateOrder(model);
            return Json(returnSummary);
        }
        public JsonResult DeleteOrder(string OrderID)
        {
            Shop_OrderService shop_OrderService = new Shop_OrderService();
            ReturnSummary returnSummary = shop_OrderService.DeleteOrder(OrderID);
            return Json(returnSummary);
        }
        public JsonResult GetOrderByID(string OrderID)
        {
            Shop_OrderService shop_OrderService = new Shop_OrderService();
            ReturnSummary returnSummary = shop_OrderService.GetOrderByID(OrderID);
            return Json(returnSummary);
        }
        public JsonResult GetOrderList(OrderQuery query)
        {
            Shop_OrderService shop_OrderService = new Shop_OrderService();
            ReturnSummary returnSummary = shop_OrderService.GetOrderList(query);
            return Json(returnSummary);
        }
    }
}
