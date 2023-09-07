using AutoMapper;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Patients;
using Sysme.Domain.Entities.Schedules;
using Sysme.Service.DTOs.Appointments;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.DTOs.Schedules;

namespace Sysme.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Appointment
        CreateMap<Appointment, AppointmentCreationDto>().ReverseMap();
        CreateMap<AppointmentUpdateDto, Appointment>().ReverseMap();
        CreateMap<AppointmentResultDto, Appointment>().ReverseMap();

        //Doctor
        CreateMap<Doctor, DoctorCreationDto>().ReverseMap();
        CreateMap<DoctorUpdateDto, Doctor>().ReverseMap();
        CreateMap<DoctorResultDto, Doctor>().ReverseMap();

        //Hospital
        CreateMap<Hospital, HospitalCreationDto>().ReverseMap();
        CreateMap<HospitalUpdateDto, Hospital>().ReverseMap();
        CreateMap<HospitalResultDto, Hospital>().ReverseMap();

        //Patient
        CreateMap<Patient, PatientCreationDto>().ReverseMap();
        CreateMap<PatientUpdateDto, Patient>().ReverseMap();
        CreateMap<PatientResultDto, Patient>().ReverseMap();

        //Schedule
        CreateMap<Schedule, ScheduleCreationDto>().ReverseMap();
        CreateMap<ScheduleUpdateDto, Schedule>().ReverseMap();
        CreateMap<ScheduleResultDto, Schedule>().ReverseMap();
    }
}
