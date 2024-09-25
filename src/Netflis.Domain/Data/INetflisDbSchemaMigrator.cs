using System.Threading.Tasks;

namespace Netflis.Data;

public interface INetflisDbSchemaMigrator
{
    Task MigrateAsync();
}
