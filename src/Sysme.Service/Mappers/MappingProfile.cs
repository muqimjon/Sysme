using AutoMapper;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Attachments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Employees;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Patients;
using Sysme.Domain.Entities.Schedules;
using Sysme.Service.DTOs.Appointments;
using Sysme.Service.DTOs.Attachments;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.DTOs.Employees;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.DTOs.Schedules;

namespace Sysme.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Appointment
        CreateMap<Appointment, AppointmentResultDto>().ReverseMap();
        CreateMap<AppointmentUpdateDto, Appointment>().ReverseMap();
        CreateMap<AppointmentCreationDto, Appointment>().ReverseMap();

        //Doctor
        CreateMap<Doctor, DoctorResultDto>().ReverseMap();
        CreateMap<DoctorUpdateDto, Doctor>().ReverseMap();
        CreateMap<DoctorCreationDto, Doctor>().ReverseMap();

        //Hospital
        CreateMap<Hospital, HospitalResultDto>().ReverseMap();
        CreateMap<HospitalUpdateDto, Hospital>().ReverseMap();
        CreateMap<HospitalCreationDto, Hospital>().ReverseMap();

        //Patient
        CreateMap<Patient, PatientResultDto>().ReverseMap();
        CreateMap<PatientUpdateDto, Patient>().ReverseMap();
        CreateMap<PatientCreationDto, Patient>().ReverseMap();

        //Schedule
        CreateMap<Schedule, ScheduleResultDto>().ReverseMap();
        CreateMap<ScheduleUpdateDto, Schedule>().ReverseMap();
        CreateMap<ScheduleCreationDto, Schedule>().ReverseMap();

        //Attachment
        CreateMap<AttachmentResultDto, Attachment>().ReverseMap();

        //Employee
        CreateMap<Employee, EmployeeResultDto>().ReverseMap();
        CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        CreateMap<EmployeeCreationDto, Employee>().ReverseMap();
    }
}