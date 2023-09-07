using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Patients;
using Sysme.Service.DTOs.Appointments;
using Sysme.Service.Exceptions;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> repository;
    private readonly IRepository<Doctor> doctorRepository;
    private readonly IRepository<Patient> patientRepository;
    private readonly IMapper mapper;
    public AppointmentService(IRepository<Appointment> repository, IMapper mapper, IRepository<Doctor> doctorRepository, IRepository<Patient> patientRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.doctorRepository = doctorRepository;
        this.patientRepository = patientRepository;
    }
    public async Task<AppointmentResultDto> AddAsync(AppointmentCreationDto dto)
    {
        var existDoctor = await doctorRepository.GetAsync(h => h.Id.Equals(dto.DoctorId))
            ?? throw new NotFoundException("This doctor not found");
        var existPatient = await patientRepository.GetAsync(h => h.Id.Equals(dto.PatientId))
            ?? throw new NotFoundException("This patient not found");
        var mappedAppointment = mapper.Map<Appointment>(dto);
        mappedAppointment.Doctor = existDoctor;
        mappedAppointment.Patient = existPatient;

        await repository.CreateAsync(mappedAppointment);
        await repository.SaveChanges();

        return mapper.Map<AppointmentResultDto>(mappedAppointment);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var existAppointment = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Appointment not found");

        repository.Delete(existAppointment);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<AppointmentResultDto>> RetrieveAllAsync()
    {
        var allAppointments = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<AppointmentResultDto>>(allAppointments);
    }

    public async Task<AppointmentResultDto> RetrieveByIdAsync(long id)
    {
        var existAppointment = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Appointment not found");

        return mapper.Map<AppointmentResultDto>(existAppointment);
    }

    public async Task<AppointmentResultDto> ModifyAsync(AppointmentUpdateDto dto)
    {
        var existAppointment = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This Appointment not found");

        mapper.Map(dto, existAppointment);
        repository.Update(existAppointment);
        await repository.SaveChanges();

        return mapper.Map<AppointmentResultDto>(existAppointment);
    }
}