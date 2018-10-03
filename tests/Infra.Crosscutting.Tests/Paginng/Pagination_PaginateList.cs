using FluentAssertions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Paging
{
    public class Pagination_PaginateList
    {
        [Fact]
        public void PaginateListWithReminderSuccessfully()
        {
            List<TestObject1> values = GetQuery(55).ToList();
            Pagination pagination = new Pagination(0, 10);

            PagedList<TestObject1> paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
        }


        [Fact]
        public void PaginateListAsyncWithReminderSuccessfully()
        {
            List<TestObject1> values = GetQuery(55).ToList();
            Pagination pagination = new Pagination(0, 10);

            PagedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedAscendingGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Pagination pagination = new Pagination(0, 10, "Id", true);

            PagedList<TestObject1> paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedAscendingAsyncGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Pagination pagination = new Pagination(0, 10, "Id", true);

            PagedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(0));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedDescendingGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Pagination pagination = new Pagination(0, 10, "Id", false);

            PagedList<TestObject1> paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
            paginateResult.TotalCount.Should().Be(values.Count);
        }

        [Fact]
        public void ReturnListOrderedDescendingAsyncGivenIndexAndSize()
        {
            List<TestObject1> values = GetQuery().ToList();
            Pagination pagination = new Pagination(0, 10, "Id", false);

            PagedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull().And.HaveCount(10).And.HaveElementAt(0, values.ElementAt(99));
            paginateResult.TotalCount.Should().Be(100);
        }

        [Fact]
        public void ReturnPageListGivenZeroSize()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 0);

            PagedList<TestObject1> paginateResult = values.PaginateList(pagination) as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull();
            paginateResult.TotalCount.Should().Be(100);
        }

        [Fact]
        public void ReturnListGivenZeroSizeAsync()
        {
            IEnumerable<TestObject1> values = GetQuery();
            Pagination pagination = new Pagination(0, 0);

            PagedList<TestObject1> paginateResult = values.PaginateListAsync(pagination).GetAwaiter().GetResult() as PagedList<TestObject1>;

            paginateResult.Should().NotBeNull();
            paginateResult.TotalCount.Should().Be(100);
        }

        private IQueryable<TestObject1> GetQuery()
        {
            return GetQuery(100);
        }

        private IQueryable<TestObject1> GetQuery(int length)
        {
            List<TestObject1> query = new List<TestObject1>();

            for (int i = 1; i <= length; i++)
            {
                query.Add(new TestObject1 { Id = i, TestObject2Id = i, TestObject2 = new TestObject2 { Id = i } });
            }

            return query.AsQueryable();
        }
    }
}
