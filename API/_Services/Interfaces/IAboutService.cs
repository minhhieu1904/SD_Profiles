using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IAboutService
    {
        Task<bool> Create(AboutDto dataDto);
        Task<bool> Update(AboutDto dataDto);
        Task<bool> Delete(AboutDto dataDto);
        Task<bool> SetDefault(AboutDto dataDto);
        Task<PaginationUtility<AboutDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true);
    }
}