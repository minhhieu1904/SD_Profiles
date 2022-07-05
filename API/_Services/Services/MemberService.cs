using API._Repositories;
using API._Services.Interfaces;
using API.Dtos;
using API.Models;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SD3_API.Helpers.Utilities;

namespace API._Services.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IMapper _mapper;

        public MemberService(
            IRepositoryAccessor repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create(MemberDto dataDto)
        {
            dataDto.Status = true;
            dataDto.Create_Time = DateTime.Now;
            var data = _mapper.Map<Member>(dataDto);
            _repository.Member.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> Delete(MemberDto dataDto)
        {
            dataDto.Status = false;
            return await Update(dataDto);
        }

        public async Task<PaginationUtility<MemberDto>> GetDataPagination(PaginationParam pagination, string text, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<Member>(x => x.Status.Value);
            if(!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();
                pred.And(x => x.Name.ToLower().Contains(text) || x.Address.ToLower().Contains(text) || x.Email.ToLower().Contains(text) || x.Phone.Contains(text));
            }

            var data = _repository.Member.FindAll(pred).AsNoTracking()
                .Join(_repository.Position.FindAll(x => x.Status.Value).AsNoTracking(),
                    x => x.Position_Id,
                    y => y.Id,
                    (x, y) => new MemberDto {
                        Address = x.Address,
                        Avatar = x.Avatar,
                        Create_By = x.Create_By,
                        Create_Time = x.Create_Time,
                        Description = x.Description,
                        Email = x.Email,
                        Id = x.Id,
                        Name = x.Name,
                        Phone = x.Phone,
                        Position_Id = x.Position_Id,
                        Position_Name = y.Name,
                        Skill = x.Skill,
                        Status = x.Status,
                        Update_By = x.Update_By,
                        Update_Time = x.Update_Time
                    }
                );
            return await PaginationUtility<MemberDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<bool> Update(MemberDto dataDto)
        {
            dataDto.Update_Time = DateTime.Now;
            var data = _mapper.Map<Member>(dataDto);
            _repository.Member.Update(data);
            return await _repository.Save();
        }
    }
}