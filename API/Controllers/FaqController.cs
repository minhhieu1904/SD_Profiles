using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class FaqController : ApiController
    {
        private readonly IFaqService _faqService;

        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(FaqDto dataDto)
        {
            dataDto.Create_By = userName;
            return Ok(await _faqService.Create(dataDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(FaqDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _faqService.Update(dataDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(FaqDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _faqService.Delete(dataDto));
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string text)
        {
            return Ok(await _faqService.GetDataPagination(pagination, text));
        }
    }
}