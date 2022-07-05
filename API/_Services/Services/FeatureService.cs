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
    public class FeatureService : IFeatureService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapConfiguration;

        public FeatureService(
            IRepositoryAccessor repository, 
            IMapper mapper, 
            MapperConfiguration mapConfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            _mapConfiguration = mapConfiguration;
        }

        public async Task<bool> Create(FeatureDto dataDto)
        {
            dataDto.Status = true;
            dataDto.Create_Time = DateTime.Now;
           var data = _mapper.Map<Feature>(dataDto);
            _repository.Feature.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> Delete(FeatureDto dataDto)
        {
            dataDto.Status = false;
            return await Update(dataDto);
        }

        public async Task<PaginationUtility<FeatureDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<Feature>(x => x.Status.Value);
            if(!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();
                pred.And(x => x.Title.ToLower().Contains(text) || x.Description.ToLower().Contains(text));
            }

            var data = _repository.Feature.FindAll(pred).ProjectTo<FeatureDto>(_mapConfiguration).AsNoTracking();
            return await PaginationUtility<FeatureDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<bool> Update(FeatureDto dataDto)
        {
            dataDto.Update_Time = DateTime.Now;
            var data = _mapper.Map<Feature>(dataDto);
            _repository.Feature.Update(data);
            return await _repository.Save();
        }
    }
}