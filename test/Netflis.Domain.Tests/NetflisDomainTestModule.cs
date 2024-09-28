using Volo.Abp.Modularity;

namespace Netflis;

[DependsOn(
    typeof(NetflisDomainModule),
    typeof(NetflisTestBaseModule)
)]
public class NetflisDomainTestModule : AbpModule
{

}
