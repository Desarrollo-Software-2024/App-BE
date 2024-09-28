using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Netflis.Data;

/* This is used if database provider does't define
 * INetflisDbSchemaMigrator implementation.
 */
public class NullNetflisDbSchemaMigrator : INetflisDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
