using Microsoft.Extensions.Localization;
using Netflis.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Netflis;

[Dependency(ReplaceServices = true)]
public class NetflisBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<NetflisResource> _localizer;

    public NetflisBrandingProvider(IStringLocalizer<NetflisResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
