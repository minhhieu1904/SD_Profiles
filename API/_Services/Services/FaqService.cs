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
    public class FaqService : IFaqService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapConfiguration;

        public FaqService(
            IRepositoryAccessor repository, 
            IMapper mapper, 
            MapperConfiguration mapConfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            _mapConfiguration = mapConfiguration;
        }

        public async Task<bool> Create(FaqDto dataDto)
        {
            dataDto.Status = true;
            dataDto.Create_Time = DateTime.Now;
            var data = _mapper.Map<Faq>(dataDto);
            _repository.Faq.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> Delete(FaqDto dataDto)
        {
            dataDto.Status = false;
            return await Update(dataDto);
        }

        public async Task<PaginationUtility<FaqDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<Faq>(x => x.Status.Value);
            if(!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();
                pred.And(x => x.Title.ToLower().Contains(text) || x.Description.ToLower().Contains(text));
            }

            var data = _repository.Faq.FindAll(pred).ProjectTo<FaqDto>(_mapConfiguration).AsNoTracking();
            return await PaginationUtility<FaqDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<bool> Update(FaqDto dataDto)
        {
            dataDto.Update_Time = DateTime.Now;
            var data = _mapper.Map<Faq>(dataDto);
            _repository.Faq.Update(data);
            return await _repository.Save();
        }
    }
}