using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IFaqService
    {
        Task<bool> Create(FaqDto dataDto);
        Task<bool> Update(FaqDto dataDto);
        Task<bool> Delete(FaqDto dataDto);
        Task<PaginationUtility<FaqDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true);
    }
}