using Netflis.Samples;
using Xunit;

namespace Netflis.EntityFrameworkCore.Domains;

[Collection(NetflisTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<NetflisEntityFrameworkCoreTestModule>
{

}
