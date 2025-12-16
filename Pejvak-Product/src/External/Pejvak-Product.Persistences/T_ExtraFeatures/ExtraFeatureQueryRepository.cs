using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ExtraFeatures.Contracts;
using Pejvak_Product.Services.ExtraFeatures.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_ExtraFeatures
{
    public class ExtraFeatureQueryRepository : IExtraFeatureQuery
    {
        private readonly EFDataContext _context;

        public ExtraFeatureQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetExtraFeatureDto?> GetExtraFeature()
        {
            return await _context.ExtraFeatures
                .Select(_ => new GetExtraFeatureDto
                {
                    Id = _.Id,
                    ProductInstanceId = _.ProductInstanceId,
                    ExtraFeatures = _.ExtraFeatures
                })
                .FirstOrDefaultAsync();
        }
    }
}
