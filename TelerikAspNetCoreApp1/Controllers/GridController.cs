using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TelerikAspNetCoreApp1.Models;

namespace TelerikAspNetCoreApp1.Controllers;
public class GridController : Controller
{
    public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
    {
        var result = Enumerable.Range(2, 51).Select(i => new OrderViewModel
        {
            OrderID = i,
            Freight = i * 10,
            OrderDate = new DateTime(2023, 9, 15).AddDays(i % 7),
            ShipName = "ShipName " + i,
            ShipCity = "ShipCity " + i
        });

        var customRet = result.ToList();

        customRet.Insert(0,  new OrderViewModel
        {
            OrderID = 1,
            Freight = 1 * 10,
            OrderDate = new DateTime(2023, 9, 15).AddDays(1 % 7),
            ShipName = "Brazil",
            ShipCity = "Porto Alegre"
        });


        var dsResult = customRet.ToDataSourceResult(request);
        return Json(dsResult);
    }
}
