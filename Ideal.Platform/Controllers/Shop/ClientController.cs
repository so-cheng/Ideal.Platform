using Ideal.Ideal.Model;
using Ideal.Shop.Model.Query;
using Ideal.Shop.Model;
using Ideal.Shop.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers.Shop
{
    public class ClientController : Controller
    {
        public JsonResult InsertClient(Shop_ClientModel model)
        {
            Shop_ClientService shop_ClientService = new Shop_ClientService();
            ReturnSummary returnSummary = shop_ClientService.InsertClient(model);
            return Json(returnSummary);
        }
        public JsonResult UpdateClient(Shop_ClientModel model)
        {
            Shop_ClientService shop_ClientService = new Shop_ClientService();
            ReturnSummary returnSummary = shop_ClientService.UpdateClient(model);
            return Json(returnSummary);
        }
        public JsonResult DeleteClient(string ClientID)
        {
            Shop_ClientService shop_ClientService = new Shop_ClientService();
            ReturnSummary returnSummary = shop_ClientService.DeleteClient(ClientID);
            return Json(returnSummary);
        }
        public JsonResult GetClientByID(string ClientID)
        {
            Shop_ClientService shop_ClientService = new Shop_ClientService();
            ReturnSummary returnSummary = shop_ClientService.GetClientByID(ClientID);
            return Json(returnSummary);
        }
        public JsonResult GetClientList(OrderQuery query)
        {
            Shop_ClientService shop_ClientService = new Shop_ClientService();
            ReturnSummary returnSummary = shop_ClientService.GetClientList(query);
            return Json(returnSummary);
        }
    }
}
