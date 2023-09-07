using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Schedules;
using Sysme.Service.DTOs.Schedules;
using Sysme.Service.Exceptions;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class ScheduleService : IScheduleService
{
    private readonly IRepository<Schedule> repository;
    private readonly IRepository<Doctor> doctorRepository;
    private readonly IMapper mapper;
    public ScheduleService(IRepository<Schedule> repository, IMapper mapper, IRepository<Doctor> doctorRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.doctorRepository = doctorRepository;
    }
    public async Task<ScheduleResultDto> AddAsync(ScheduleCreationDto dto)
    {
        var existDoctor = await doctorRepository.GetAsync(h => h.Id.Equals(dto.DoctorId))
            ?? throw new NotFoundException("This hospital not found");
        var mappedSchedule = mapper.Map<Schedule>(dto);
        mappedSchedule.Doctor = existDoctor;
        await repository.CreateAsync(mappedSchedule);
        await repository.SaveChanges();

        return mapper.Map<ScheduleResultDto>(mappedSchedule);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var existSchedule = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Schedule not found");

        repository.Delete(existSchedule);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<ScheduleResultDto>> RetrieveAllAsync()
    {
        var allSchedules = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<ScheduleResultDto>>(allSchedules);
    }

    public async Task<ScheduleResultDto> RetrieveByIdAsync(long id)
    {
        var existSchedule = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Schedule not found");

        return mapper.Map<ScheduleResultDto>(existSchedule);
    }

    public async Task<ScheduleResultDto> ModifyAsync(ScheduleUpdateDto dto)
    {
        var existSchedule = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This Schedule not found");

        mapper.Map(dto, existSchedule);
        repository.Update(existSchedule);
        await repository.SaveChanges();

        return mapper.Map<ScheduleResultDto>(existSchedule);
    }
}