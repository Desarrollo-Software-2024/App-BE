using Netflis.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Netflis.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NetflisEntityFrameworkCoreModule),
    typeof(NetflisApplicationContractsModule)
)]
public class NetflisDbMigratorModule : AbpModule
{
}
