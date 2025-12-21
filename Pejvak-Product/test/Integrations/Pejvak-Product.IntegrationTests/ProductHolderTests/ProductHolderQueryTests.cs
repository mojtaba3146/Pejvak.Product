using FluentAssertions;
using Pejvak_Product.Domain.ExtraFeatures;
using Pejvak_Product.Domain.GroupPrices;
using Pejvak_Product.Domain.ProductInstanceProperties;
using Pejvak_Product.Domain.ProductProductGroups;
using Pejvak_Product.Domain.ProductProperties;
using Pejvak_Product.Domain.T_ProductHolders;
using Pejvak_Product.Domain.T_ProductInstances;
using Pejvak_Product.Domain.T_Products;
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

        [Fact]
        public async Task GetUserAvailableFeatures_Should_return_all_data_properly()
        {
            var userId = 3146;
            var product = new T_Product
            {
                Name = "Test Product",
                ExclusiveCode = "EX123",
                ProductType = "TypeA",
                AssociateId = 1,
                ProductGroupId = 1,
                IsActive = 1,
                IsDeleted = 0,
                Price = 1000,
                IsCenter = 0,
                ClientDiscountPercantage = 10.0,
                ProductTypeId = 1
            };
            Save(product);
            var productInstance = new T_ProductInstance
            {
                ProductId = product.Id,
                LockSerial = "LOCK123",
                ProductDate = DateTime.UtcNow,
                IsActive = 1,
                IsDeleted = 0,
                IsItPrince = true,
                StatusLock = 0,
                ActivationStatus = 1
            };
            Save(productInstance);
            var productHolder = new T_ProductHolder
            {
                UserId = userId,
                ProductInstanceId = productInstance.Id,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                IsDeleted = 0
            };
            Save(productHolder);
            var productProperty = new T_ProductProperties
            {
                PropertyTitle = "Feature A",
                UniqueCode = "FEAT_A",
                IsActive = 1,
                IsDeleted = 0,
                IsTimeSensitive = false
            };
            Save(productProperty);
            var groupPrice = new T_GroupPrice
            {
                PropertyId = productProperty.Id,
                Price = 500,
                Description = "Group Price A",
                IsActive = 1,
                IsDeleted = 0
            };
            Save(groupPrice);
            var productProductGroup = new T_ProductProductGroup
            {
                PropertyId= productProperty.Id,
                ProductIds = product.Id.ToString(),
                IsDeleted = 0,
                IsActive = 1
            };
            Save(productProductGroup);
            var productInstanceProperty = new T_ProductInstanceProperties
            {
                ProductId = product.Id,
                Version = "1.0",
                Properties = "10,11",
                IsActive = 1,
                IsDeleted = 0
            };
            Save(productInstanceProperty);
            var extraFeature = new T_ExtraFeatures
            {
                ProductInstanceId = productInstance.Id,
                ExtraFeatures = "Extra1, Extra2",
                IsDeleted = 0,
                Confirmed = 1
            };
            Save(extraFeature);

            var expected = await _sut.GetUserAvailableFeatures(userId);

            expected.Should().NotBeNull();
            expected.First().UserId.Should().Be(userId);
            expected.First().ProductInstanceId.Should().Be(productInstance.Id);
            expected.First().ProductId.Should().Be(product.Id);
            expected.First().ProductName.Should().Be(product.Name);
            expected.First().LockSerial.Should().Be(productInstance.LockSerial);
            expected.First().ProductHolderId.Should().Be(productHolder.Id);
            expected.First().ProductProperties.First().Price.Should().Be(groupPrice.Price);
            expected.First().ProductProperties.First().PropertyTitle.Should().Be(productProperty.PropertyTitle);
            expected.First().ProductProperties.First().PropertyId.Should().Be(productProperty.Id);
            expected.First().ProductProperties.First().PriceDescription.Should().Be(groupPrice.Description);
            expected.First().AllAvailableProductProperties.First().PropertyId.Should().Be(productProperty.Id);
            expected.First().AllAvailableProductProperties.First().PropertyTitle.Should().Be(productProperty.PropertyTitle);
            expected.First().AllAvailableProductProperties.First().Price.Should().Be(groupPrice.Price);
            expected.First().DefaultProductProperties.Should().BeNullOrEmpty();
            expected.First().UserBoughtProductProperties.Should().BeNullOrEmpty();
        }
    }
}
