using Tests.Common;
using AuctriaProject.Application.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using static Tests.Common.CommonFixture;

namespace AuctriaProject.Infrastructure.Test
{
    public class RepoUnitTests : IClassFixture<CommonFixture>
    {
        private readonly ServiceProvider _serviceProvider;
        public RepoUnitTests(CommonFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetAllItems()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var itemRepository = scope.ServiceProvider.GetRequiredService<IItemRepository>();

                var data = await itemRepository.GetAllItems();

                Assert.True(data.Any());
            }
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetAllShoppingItems()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var shoppingCardRepository = scope.ServiceProvider.GetRequiredService<IShoppingCardRepository>();

                var data = await shoppingCardRepository.GetAllShoppingItems(1);

                Assert.True(data.Any());
            }
        }
    }
}