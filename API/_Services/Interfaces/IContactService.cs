using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IContactService
    {
        Task<bool> Create(ContactDto dataDto);
        Task<bool> Update(ContactDto dataDto);
        Task<bool> Delete(ContactDto dataDto);
        Task<PaginationUtility<ContactDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true);
    }
}