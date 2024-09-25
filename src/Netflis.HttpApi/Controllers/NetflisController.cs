using Netflis.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Netflis.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NetflisController : AbpControllerBase
{
    protected NetflisController()
    {
        LocalizationResource = typeof(NetflisResource);
    }
}
