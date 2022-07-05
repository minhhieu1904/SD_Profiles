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
    public class PositionService : IPositionService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapConfiguration;

        public PositionService(
            IRepositoryAccessor repository, 
            IMapper mapper, 
            MapperConfiguration mapConfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            _mapConfiguration = mapConfiguration;
        }

        public async Task<bool> Create(PositionDto dataDto)
        {
            dataDto.Status = true;
            dataDto.Create_Time = DateTime.Now;
            var data = _mapper.Map<Position>(dataDto);
            _repository.Position.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> Delete(PositionDto dataDto)
        {
            if(_repository.Member.FindAll(x => x.Position_Id == dataDto.Id).Any())
                return false;
            
            dataDto.Status = false;
            return await Update(dataDto);
        }

        public async Task<PaginationUtility<PositionDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<Position>(x => x.Status.Value);
            if(!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();
                pred.And(x => x.Name.ToLower().Contains(text));
            }

            var data = _repository.Position.FindAll(pred).ProjectTo<PositionDto>(_mapConfiguration).AsNoTracking();
            return await PaginationUtility<PositionDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<List<KeyValuePair<int, string>>> GetListPosition()
        {
            var data = await _repository.Position.FindAll(x => x.Status.Value).AsNoTracking()
                .Select(x => new KeyValuePair<int, string>(
                    x.Id,
                    x.Name
                )).ToListAsync();
            return data;
        }

        public async Task<bool> Update(PositionDto dataDto)
        {
            dataDto.Update_Time = DateTime.Now;
            var data = _mapper.Map<Position>(dataDto);
            _repository.Position.Update(data);
            return await _repository.Save();
        }
    }
}