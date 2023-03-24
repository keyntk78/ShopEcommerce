using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace ShopEcommerce.Admin.Controllers;

public class HomeAdminController : AbpController
{
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}
