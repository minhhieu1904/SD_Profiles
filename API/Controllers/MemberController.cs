using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class MemberController : ApiController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(MemberDto dataDto)
        {
            dataDto.Create_By = userName;
            return Ok(await _memberService.Create(dataDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(MemberDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _memberService.Update(dataDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(MemberDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _memberService.Delete(dataDto));
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string text)
        {
            return Ok(await _memberService.GetDataPagination(pagination, text));
        }
    }
}