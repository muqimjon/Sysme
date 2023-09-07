using AutoMapper;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class HospitalService : IHospitalService
{
    private readonly IRepository<Hospital> repository;
    private readonly IMapper mapper;
    public HospitalService(IRepository<Hospital> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public Task<HospitalResultDto> AddAsync(HospitalCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<HospitalResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<HospitalResultDto> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<HospitalResultDto> UpdateAsync(HospitalUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
