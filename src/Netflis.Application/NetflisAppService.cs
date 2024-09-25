using Netflis.Localization;
using Volo.Abp.Application.Services;

namespace Netflis;

/* Inherit your application services from this class.
 */
public abstract class NetflisAppService : ApplicationService
{
    protected NetflisAppService()
    {
        LocalizationResource = typeof(NetflisResource);
    }
}
