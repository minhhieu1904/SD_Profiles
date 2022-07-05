using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class FeatureController : ApiController
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(FeatureDto dataDto)
        {
            dataDto.Create_By = userName;
            return Ok(await _featureService.Create(dataDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(FeatureDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _featureService.Update(dataDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(FeatureDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _featureService.Delete(dataDto));
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string text)
        {
            return Ok(await _featureService.GetDataPagination(pagination, text));
        }
    }
}