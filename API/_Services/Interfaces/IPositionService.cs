using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IPositionService
    {
        Task<bool> Create(PositionDto dataDto);
        Task<bool> Update(PositionDto dataDto);
        Task<bool> Delete(PositionDto dataDto);
        Task<PaginationUtility<PositionDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true);
        Task<List<KeyValuePair<int, string>>> GetListPosition();
    }
}