using Netflis.Samples;
using Xunit;

namespace Netflis.EntityFrameworkCore.Applications;

[Collection(NetflisTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<NetflisEntityFrameworkCoreTestModule>
{

}
