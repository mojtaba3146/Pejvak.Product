using FluentAssertions;
using Pejvak_Product.Domain.ExtraFeatures;
using Pejvak_Product.IntegrationTests.Infrastructure;
using Pejvak_Product.Persistences.T_ProductHolders;
using Pejvak_Product.Services.ProductHolders.Contracts;

namespace Pejvak_Product.IntegrationTests.ProductHolderTests
{
    public class ProductHolderQueryTests : IntegrationTestPersistence
    {
        private readonly IProductHolderQuery _sut;

        public ProductHolderQueryTests()
        {
            _sut = new ProductHolderQueryRepository(Context);
        }

       
    }
}
