using Volo.Abp.Modularity;

namespace Netflis;

/* Inherit from this class for your domain layer tests. */
public abstract class NetflisDomainTestBase<TStartupModule> : NetflisTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
