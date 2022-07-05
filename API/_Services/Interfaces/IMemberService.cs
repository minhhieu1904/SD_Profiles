using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IMemberService
    {
        Task<bool> Create(MemberDto dataDto);
        Task<bool> Update(MemberDto dataDto);
        Task<bool> Delete(MemberDto dataDto);
        Task<PaginationUtility<MemberDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true);
    }
}