using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.Exceptions;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper mapper;
    private readonly IRepository<Doctor> repository;
    private readonly IRepository<Hospital> hospitalRepository;
    public DoctorService(IRepository<Doctor> repository, IMapper mapper, IRepository<Hospital> hospitalRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.hospitalRepository = hospitalRepository;
    }
    public async Task<DoctorResultDto> AddAsync(DoctorCreationDto dto)
    {
        var existHospital = await hospitalRepository.GetAsync(h => h.Id.Equals(dto.HospitalId))
            ?? throw new NotFoundException("This hospital not found");
        var mappedDoctor = mapper.Map<Doctor>(dto);
        mappedDoctor.Hospital = existHospital;
        await repository.CreateAsync(mappedDoctor);
        await repository.SaveChanges();

        return mapper.Map<DoctorResultDto>(mappedDoctor);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var existDoctor = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Doctor not found");

        repository.Delete(existDoctor);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<DoctorResultDto>> RetrieveAllAsync()
    {
        var allDoctors = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<DoctorResultDto>>(allDoctors);
    }

    public async Task<DoctorResultDto> RetrieveByIdAsync(long id)
    {
        var existDoctor = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Doctor not found");

        return mapper.Map<DoctorResultDto>(existDoctor);
    }

    public async Task<DoctorResultDto> ModifyAsync(DoctorUpdateDto dto)
    {
        var existDoctor = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This Doctor not found");

        mapper.Map(dto, existDoctor);
        repository.Update(existDoctor);
        await repository.SaveChanges();

        return mapper.Map<DoctorResultDto>(existDoctor);
    }
}