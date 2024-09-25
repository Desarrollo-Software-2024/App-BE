using Xunit;

namespace Netflis.EntityFrameworkCore;

[CollectionDefinition(NetflisTestConsts.CollectionDefinitionName)]
public class NetflisEntityFrameworkCoreCollection : ICollectionFixture<NetflisEntityFrameworkCoreFixture>
{

}
