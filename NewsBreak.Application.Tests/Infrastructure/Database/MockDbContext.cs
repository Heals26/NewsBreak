using Microsoft.EntityFrameworkCore;
using Moq;

namespace NewsBreak.Application.Tests.Infrastructure.Database
{

    public static class MockDbContext
    {

        #region Mock Queryable

        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var _Queryable = sourceList.AsQueryable();
            var _DbSet = new Mock<DbSet<T>>();

            _DbSet.As<IQueryable<T>>().Setup(mock => mock.Provider).Returns(_Queryable.Provider);
            _DbSet.As<IQueryable<T>>().Setup(mock => mock.Expression).Returns(_Queryable.Expression);
            _DbSet.As<IQueryable<T>>().Setup(mock => mock.ElementType).Returns(_Queryable.ElementType);
            _DbSet.As<IQueryable<T>>().Setup(mock => mock.GetEnumerator()).Returns(_Queryable.GetEnumerator());

            _DbSet.Setup(mock => mock.Add(It.IsAny<T>())).Callback<T>((source) => sourceList.Add(source));
            _DbSet.Setup(mock => mock.AddRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>((source) => sourceList.AddRange(source));
            _DbSet.Setup(mock => mock.Remove(It.IsAny<T>())).Callback<T>((source) => sourceList.Remove(source));

            return _DbSet.Object;
        }

        #endregion Mock Queryable

    }

}
