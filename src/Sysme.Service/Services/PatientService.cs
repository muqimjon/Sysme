using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Patients;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.Exceptions;
using Sysme.Service.Helpers;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class PatientService : IPatientService
{
    private readonly IRepository<Patient> repository;
    private readonly IMapper mapper;
    public PatientService(IRepository<Patient> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<PatientResultDto> AddAsync(PatientCreationDto dto)
    {
        var existPatient = await repository.GetAsync(h => h.Phone == dto.Phone);
        if (existPatient is not null)
            throw new AlreadyExistException("This Patient already exist");

        var mappedPatient = mapper.Map<Patient>(dto);
        mappedPatient.Password = PasswordHasher.Hash(dto.Password);
        await repository.CreateAsync(mappedPatient);
        await repository.SaveChanges();

        return mapper.Map<PatientResultDto>(mappedPatient);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var existPatient = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Patient not found");

        repository.Delete(existPatient);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<PatientResultDto>> RetrieveAllAsync()
    {
        var allPatients = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<PatientResultDto>>(allPatients);
    }

    public async Task<PatientResultDto> RetrieveByIdAsync(long id)
    {
        var existPatient = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Patient not found");

        return mapper.Map<PatientResultDto>(existPatient);
    }

    public async Task<PatientResultDto> ModifyAsync(PatientUpdateDto dto)
    {
        var existPatient = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This Patient not found");

        mapper.Map(dto, existPatient);
        repository.Update(existPatient);
        await repository.SaveChanges();

        return mapper.Map<PatientResultDto>(existPatient);
    }
}