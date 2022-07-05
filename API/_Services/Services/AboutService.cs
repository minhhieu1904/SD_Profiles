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
    public class AboutService : IAboutService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapConfiguration;

        public AboutService(
            IRepositoryAccessor repository, 
            IMapper mapper, 
            MapperConfiguration mapConfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            _mapConfiguration = mapConfiguration;
        }

        public async Task<bool> Create(AboutDto dataDto)
        {
            dataDto.Status = true;
            dataDto.Create_Time = DateTime.Now;
            var data = _mapper.Map<About>(dataDto);
            _repository.About.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> Delete(AboutDto dataDto)
        {
            dataDto.Status = false;
            return await Update(dataDto);
        }

        public async Task<PaginationUtility<AboutDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<About>(x => x.Status.Value);
            if(!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();
                pred.And(
                    x => x.Email.ToLower().Contains(text) || 
                    x.Address.ToLower().Contains(text) || 
                    x.Phone.Contains(text) || 
                    x.Title.ToLower().Contains(text) ||
                    x.Description.ToLower().Contains(text)
                );
            }

            var data = _repository.About.FindAll(pred).ProjectTo<AboutDto>(_mapConfiguration).AsNoTracking();
            return await PaginationUtility<AboutDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<bool> SetDefault(AboutDto dataDto)
        {
            var data = await _repository.About.FindAll(x => x.Status.Value && !x.IsDefault.Value).AsNoTracking().ToListAsync();
            if(data.Any())
            {
                data.ForEach(item => item.IsDefault = false);
                _repository.About.UpdateMultiple(data);
            }

            dataDto.IsDefault = true;
            return await Update(dataDto);
        }

        public async Task<bool> Update(AboutDto dataDto)
        {
            dataDto.Update_Time = DateTime.Now;
            var data = _mapper.Map<About>(dataDto);
            _repository.About.Update(data);
            return await _repository.Save();
        }
    }
}