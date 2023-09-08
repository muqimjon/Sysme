using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Service.DTOs.Appointments;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.Exceptions;
using Sysme.Service.Helpers;
using Sysme.Service.Interfaces;
using System.Collections;

namespace Sysme.Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper mapper;
    private readonly IRepository<Doctor> repository;
    private readonly IRepository<Hospital> hospitalRepository;
    private readonly IRepository<Appointment> appointmentRepository;
    public DoctorService(IRepository<Doctor> repository, IMapper mapper, IRepository<Hospital> hospitalRepository, IRepository<Appointment> appointmentRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.hospitalRepository = hospitalRepository;
        this.appointmentRepository = appointmentRepository;
    }
    public async Task<DoctorResultDto> AddAsync(DoctorCreationDto dto)
    {
        var existDocotor = await repository.GetAsync(x => x.Phone.Equals(dto.Phone));
        if (existDocotor is not null)
            throw new AlreadyExistException("This doctor is already exist!");

        var existHospital = await hospitalRepository.GetAsync(h => h.Id.Equals(dto.HospitalId))
            ?? throw new NotFoundException("This hospital not found");

        var mappedDoctor = mapper.Map<Doctor>(dto);
        mappedDoctor.Password = PasswordHasher.Hash(dto.Password);
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
        var allDoctors = await repository.GetAll(includes: new[] {"Hospital"}).ToListAsync();
        return mapper.Map<IEnumerable<DoctorResultDto>>(allDoctors);
    }

    public async Task<DoctorResultDto> RetrieveByIdAsync(long id)
    {
        var existDoctor = await repository.GetAsync(h => h.Id.Equals(id), includes: new[] { "Hospital" })
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

    public async Task<IEnumerable<DoctorResultDto>> SearchByQuery(string query)
    {
        var result = await repository.GetAll(includes: new[] {"Hospital"}).Where(d => d.Specialty.Contains(query) || d.Hospital.Name.Contains(query) 
        || d.FirstName.Contains(query) || d.LastName.Contains(query) || d.Email.Contains(query) || d.Phone.Contains(query)).ToListAsync();
        if (result is null)
            return null;

        return mapper.Map<IEnumerable<DoctorResultDto>>(result);
    }

    public async Task<List<Dictionary<string, bool>>> GetPlan(long id)
    {
        var appointments = appointmentRepository.GetAll(a => a.DoctorId == id && a.AppointmentTime > DateTime.UtcNow).AsEnumerable();
        var doctor = await repository.GetAsync(d => d.Id == id, new[] { "Schedule" });
        var schedules = doctor.Schedules;

        var plan = new Dictionary<string, bool>();
        var plans = new List<Dictionary<string,bool>>();

        foreach (var schedule in schedules)
        {
            while (schedule.StartTime < schedule.EndTime)
            {
                var free = !appointments.Any(a => a.AppointmentTime.Equals(schedule.StartTime));
                plan.Add($"{schedule.StartTime}-{schedule.StartTime.Add(schedule.InspectionTime)}", free);
            }
            plans.Add(plan);
        }

        return plans;
    }
}