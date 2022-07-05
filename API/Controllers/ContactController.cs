using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ContactDto dataDto)
        {
            dataDto.Create_By = userName;
            return Ok(await _contactService.Create(dataDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ContactDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _contactService.Update(dataDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(ContactDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _contactService.Delete(dataDto));
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string text)
        {
            return Ok(await _contactService.GetDataPagination(pagination, text));
        }
    }
}