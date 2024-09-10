using Volo.Abp.Modularity;

namespace Netflis;

public abstract class NetflisApplicationTestBase<TStartupModule> : NetflisTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
