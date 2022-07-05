using API._Repositories;
using API._Services.Interfaces;
using API.Dtos;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SD3_API.Helpers.Utilities;

namespace API._Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapConfiguration;

        public ContactService(
            IRepositoryAccessor repository,
            IMapper mapper,
            MapperConfiguration mapConfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            _mapConfiguration = mapConfiguration;
        }

        public async Task<bool> Create(ContactDto dataDto)
        {
            dataDto.Status = true;
            dataDto.Create_Time = DateTime.Now;
            var data = _mapper.Map<Contact>(dataDto);
            _repository.Contact.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> Delete(ContactDto dataDto)
        {
            dataDto.Status = false;
            return await Update(dataDto);
        }

        public async Task<PaginationUtility<ContactDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<Contact>(x => x.Status.Value);
            if(!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();
                pred.And(x => x.Email.ToLower().Contains(text) || x.Name.ToLower().Contains(text) || x.Phone.Contains(text) || x.Subject.ToLower().Contains(text));
            }

            var data = _repository.Contact.FindAll(pred).ProjectTo<ContactDto>(_mapConfiguration).AsNoTracking();
            return await PaginationUtility<ContactDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<bool> Update(ContactDto dataDto)
        {
            dataDto.Update_Time = DateTime.Now;
            var data = _mapper.Map<Contact>(dataDto);
            _repository.Contact.Update(data);
            return await _repository.Save();
        }
    }
}