using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.Exceptions;
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
    public async Task<HospitalResultDto> AddAsync(HospitalCreationDto dto)
    {
        var existHospital = await repository.GetAsync(h => h.Name == dto.Name);
        if (existHospital is not null)
            throw new AlreadyExistException("This hospital already exist");

        var mappedHospital = mapper.Map<Hospital>(dto);
        await repository.CreateAsync(mappedHospital);
        await repository.SaveChanges();

        return mapper.Map<HospitalResultDto>(mappedHospital);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existHospital = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This hospital not found");

        repository.Delete(existHospital);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<HospitalResultDto>> GetAllAsync()
    {
        var allHospitals = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<HospitalResultDto>>(allHospitals);
    }

    public async Task<HospitalResultDto> GetAsync(long id)
    {
        var existHospital = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This hospital not found");

        return mapper.Map<HospitalResultDto>(existHospital);
    }

    public async Task<HospitalResultDto> UpdateAsync(HospitalUpdateDto dto)
    {
        var existHospital = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This hospital not found");

        mapper.Map(dto, existHospital);
        repository.Update(existHospital);
        await repository.SaveChanges();

        return mapper.Map<HospitalResultDto>(existHospital);
    }
}