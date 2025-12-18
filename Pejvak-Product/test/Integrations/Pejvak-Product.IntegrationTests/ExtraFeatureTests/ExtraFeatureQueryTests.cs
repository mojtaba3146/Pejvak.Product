using FluentAssertions;
using Pejvak_Product.Domain.ExtraFeatures;
using Pejvak_Product.IntegrationTests.Infrastructure;
using Pejvak_Product.Persistences.T_ExtraFeatures;
using Pejvak_Product.Services.ExtraFeatures.Contracts;

namespace Pejvak_Product.IntegrationTests.ExtraFeatureTests
{
    public class ExtraFeatureQueryTests : IntegrationTestPersistence
    {
        private readonly IExtraFeatureQuery _sut;

        public ExtraFeatureQueryTests()
        {
            _sut = new ExtraFeatureQueryRepository(Context);
        }

        [Fact]
        public async Task GetExtraFeature_ShouldReturnCorrectData_properly()
        {
            var extraFeature = new T_ExtraFeatures
            {
                ProductInstanceId = 33,
                ExtraFeatures = "Feature1, Feature2"
            };
            Save(extraFeature);

            var expected = await _sut.GetExtraFeature();

            expected.Should().NotBeNull();
            expected.Id.Should().Be(extraFeature.Id);
            expected.ProductInstanceId.Should().Be(extraFeature.ProductInstanceId);
            expected.ExtraFeatures.Should().Be(extraFeature.ExtraFeatures);
        }
    }
}
