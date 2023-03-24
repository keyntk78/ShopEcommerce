using ShopEcommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ShopEcommerce;

[DependsOn(
    typeof(ShopEcommerceEntityFrameworkCoreTestModule)
    )]
public class ShopEcommerceDomainTestModule : AbpModule
{

}
