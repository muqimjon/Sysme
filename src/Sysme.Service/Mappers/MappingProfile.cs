using AutoMapper;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.DTOs.Schedules;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.DTOs.Schedules;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.DTOs.Appointments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Patients;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Schedules;
using Sysme.Domain.Entities.Appointments;
using Sysme.Service.DTOs.Attachments;
using Sysme.Domain.Entities.Attachments;

namespace Sysme.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Appointment
        CreateMap<Appointment, AppointmentResultDto>();
        CreateMap<AppointmentUpdateDto, Appointment>();
        CreateMap<AppointmentCreationDto, Appointment>();

        //Doctor
        CreateMap<Doctor, DoctorResultDto>();
        CreateMap<DoctorUpdateDto, Doctor>();
        CreateMap<DoctorCreationDto, Doctor>();

        //Hospital
        CreateMap<Hospital, HospitalResultDto>();
        CreateMap<HospitalUpdateDto, Hospital>();
        CreateMap<HospitalCreationDto, Hospital>();

        //Patient
        CreateMap<Patient, PatientResultDto>();
        CreateMap<PatientUpdateDto, Patient>();
        CreateMap<PatientCreationDto, Patient>();

        //Schedule
        CreateMap<Schedule, ScheduleResultDto>();
        CreateMap<ScheduleUpdateDto, Schedule>();
        CreateMap<ScheduleCreationDto, Schedule>();

        //Attachment
        CreateMap<AttachmentResultDto, Attachment>().ReverseMap();
    }
}