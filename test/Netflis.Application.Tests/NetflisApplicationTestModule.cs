using Volo.Abp.Modularity;

namespace Netflis;

[DependsOn(
    typeof(NetflisApplicationModule),
    typeof(NetflisDomainTestModule)
)]
public class NetflisApplicationTestModule : AbpModule
{

}
