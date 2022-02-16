using Moq;
using NewsBreak.Application.Services.Data;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.Tests.Infrastructure.Database
{

    public class MockableDbContext
    {

        #region Properties

        public IBreakDBContext MockedDbContext { get; private set; }

        public List<Account> Accounts { get; set; } = new List<Account>();

        public void Setup()
        {
            var _MockDbContext = new Mock<IBreakDBContext>();
            _MockDbContext.Setup(mock => mock.Accounts).Returns(MockDbContext.GetQueryableMockDbSet(this.Accounts));

            _MockDbContext.Setup(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

            this.MockedDbContext = _MockDbContext.Object;
        }

        #endregion Properties

    }

}
