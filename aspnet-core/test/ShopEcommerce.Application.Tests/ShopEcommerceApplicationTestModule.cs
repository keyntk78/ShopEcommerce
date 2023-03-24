using Volo.Abp.Modularity;

namespace ShopEcommerce;

[DependsOn(
    typeof(ShopEcommerceApplicationModule),
    typeof(ShopEcommerceDomainTestModule)
    )]
public class ShopEcommerceApplicationTestModule : AbpModule
{

}
