using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class PositionController : ApiController
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PositionDto dataDto)
        {
            dataDto.Create_By = userName;
            return Ok(await _positionService.Create(dataDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PositionDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _positionService.Update(dataDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(PositionDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _positionService.Delete(dataDto));
        }

        [HttpGet("GetListPosition")]
        public async Task<IActionResult> GetListPosition()
        {
            return Ok(await _positionService.GetListPosition());
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string text)
        {
            return Ok(await _positionService.GetDataPagination(pagination, text));
        }
    }
}