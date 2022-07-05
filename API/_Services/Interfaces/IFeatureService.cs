using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IFeatureService
    {
        Task<bool> Create(FeatureDto dataDto);
        Task<bool> Update(FeatureDto dataDto);
        Task<bool> Delete(FeatureDto dataDto);
        Task<PaginationUtility<FeatureDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true);
    }
}